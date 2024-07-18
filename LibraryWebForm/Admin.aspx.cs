using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
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
            string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Role=@Role";
            SqlCommand command = new SqlCommand(query, db.conn);
            command.Parameters.AddWithValue("@Username", User.Identity.Name);
            command.Parameters.AddWithValue("@Role", role);

            db.conn.Open();
            int count = (int)command.ExecuteScalar();
            db.conn.Close();

            return count > 0;
        }

        private void LoadBooks(string searchTerm = "")
        {
            string query = "SELECT * FROM Books";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE Title LIKE '%' + @SearchTerm + '%' OR Author LIKE '%' + @SearchTerm + '%'";
            }

            SqlCommand command = new SqlCommand(query, db.conn);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                command.Parameters.AddWithValue("@SearchTerm", searchTerm);
            }

            DataTable dt = db.LoadDL(command);
            BooksGridView.DataSource = dt;
            BooksGridView.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchBox.Text.Trim();
            LoadBooks(searchTerm);
        }

        protected void AddNewBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddBook.aspx");
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
            int bookID = (int)BooksGridView.DataKeys[e.RowIndex].Value;
            string title = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string author = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string publisher = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string isbn = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            int genreId = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            int publicationYear = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            int quantity = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[7].Controls[0]).Text);
            int available = int.Parse(((TextBox)BooksGridView.Rows[e.RowIndex].Cells[8].Controls[0]).Text);
            string coverImageUrl = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
            string description = ((TextBox)BooksGridView.Rows[e.RowIndex].Cells[10].Controls[0]).Text;

            string query = $"UPDATE Books SET Title=@Title, Author=@Author, Publisher=@Publisher, ISBN=@ISBN, GenreId=@GenreId, PublicationYear=@PublicationYear, Quantity=@Quantity, Available=@Available, CoverImageUrl=@CoverImageUrl, Description=@Description WHERE BookID=@BookID";
            SqlCommand command = new SqlCommand(query, db.conn);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@Publisher", publisher);
            command.Parameters.AddWithValue("@ISBN", isbn);
            command.Parameters.AddWithValue("@GenreId", genreId);
            command.Parameters.AddWithValue("@PublicationYear", publicationYear);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@Available", available);
            command.Parameters.AddWithValue("@CoverImageUrl", coverImageUrl);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@BookID", bookID);

            db.ThemXoaSua(command);

            BooksGridView.EditIndex = -1;
            LoadBooks();
        }

        protected void BooksGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookID = (int)BooksGridView.DataKeys[e.RowIndex].Value;
            string query = $"DELETE FROM Books WHERE BookID=@BookID";
            SqlCommand command = new SqlCommand(query, db.conn);
            command.Parameters.AddWithValue("@BookID", bookID);
            db.ThemXoaSua(command);

            LoadBooks();
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            // Clear session if any
            Session.Abandon();

            // Clear authentication cookie
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authCookie);

            // Redirect to Home page
            Response.Redirect("~/Login.aspx");
        }
    }
}
