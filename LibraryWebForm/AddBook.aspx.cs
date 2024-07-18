using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace LibraryWebForm
{
    public partial class AddBook : Page
    {
        DatabaseConnection db = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !IsUserInRole("Admin"))
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string author = AuthorBox.Text.Trim();
            string publisher = PublisherBox.Text.Trim();
            string isbn = ISBNBox.Text.Trim();
            int genreId = int.Parse(GenreBox.Text.Trim());
            int publicationYear = int.Parse(PublicationYearBox.Text.Trim());
            int quantity = int.Parse(QuantityBox.Text.Trim());
            int available = int.Parse(AvailableBox.Text.Trim());
            string coverImageUrl = CoverImageUrlBox.Text.Trim();
            string description = DescriptionBox.Text.Trim();

            string query = $"INSERT INTO Books (Title, Author, Publisher, ISBN, GenreId, PublicationYear, Quantity, Available, CoverImageUrl, Description) VALUES (@Title, @Author, @Publisher, @ISBN, @GenreId, @PublicationYear, @Quantity, @Available, @CoverImageUrl, @Description)";
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

            db.ThemXoaSua(command);

            Response.Redirect("~/Admin.aspx");
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
    }
}
