using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebForm
{
    public partial class Admin : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!User.Identity.IsAuthenticated || !IsUserInRole("Admin"))
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadBooks();
            }
        }

        private bool IsUserInRole(string role)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Thuong Mai Dien Tu\Project\LibraryWebForm\LibraryWebForm\App_Data\Database.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Role=@Role";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", User.Identity.Name);
                command.Parameters.AddWithValue("@Role", role);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        private void LoadBooks(string searchTerm = "")
        {
            string query = "SELECT * FROM Books";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE Title LIKE '%" + searchTerm + "%' OR Author LIKE '%" + searchTerm + "%'";
            }

            DataTable dt = db.LoadDL(query);
            BooksGridView.DataSource = dt;
            BooksGridView.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchBox.Text.Trim();
            LoadBooks(searchTerm);
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string author = AuthorBox.Text.Trim();
            string publisher = PublisherBox.Text.Trim();
            string isbn = ISBNBox.Text.Trim();
            string genre = GenreBox.Text.Trim();
            int publicationYear = int.Parse(PublicationYearBox.Text.Trim());
            int quantity = int.Parse(QuantityBox.Text.Trim());
            int available = int.Parse(AvailableBox.Text.Trim());
            string coverImageUrl = CoverImageUrlBox.Text.Trim();
            string description = DescriptionBox.Text.Trim();

            string query = $"INSERT INTO Books (Title, Author, Publisher, ISBN, Genre, PublicationYear, Quantity, Available, CoverImageUrl, Description) VALUES ('{title}', '{author}', '{publisher}', '{isbn}', '{genre}', {publicationYear}, {quantity}, {available}, '{coverImageUrl}', '{description}')";
            db.ThemXoaSua(query);

            LoadBooks();
        }

        protected void BooksGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BooksGridView.EditIndex = e.NewEditIndex;
            LoadBooks();
        }

        protected void BooksGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BooksGridView.EditIndex = -1;
            LoadBooks();
        }

        protected void BooksGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int bookID = (int)e.Keys["BookID"];
            string title = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string author = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string publisher = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string isbn = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string genre = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            int publicationYear = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            int quantity = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[7].Controls[0]).Text);
            int available = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[8].Controls[0]).Text);
            string coverImageUrl = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
            string description = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[10].Controls[0]).Text;

            string query = $"UPDATE Books SET Title='{title}', Author='{author}', Publisher='{publisher}', ISBN='{isbn}', Genre='{genre}', PublicationYear={publicationYear}, Quantity={quantity}, Available={available}, CoverImageUrl='{coverImageUrl}', Description='{description}' WHERE BookID={bookID}";
            db.ThemXoaSua(query);

            BooksGridView.EditIndex = -1;
            LoadBooks();
        }

        protected void BooksGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookID = (int)e.Keys["BookID"];
            string query = $"DELETE FROM Books WHERE BookID={bookID}";
            db.ThemXoaSua(query);

            LoadBooks();
        }
    }
}
