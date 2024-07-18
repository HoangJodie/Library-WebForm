using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LibraryWebForm
{
    public partial class BookDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBookDetails();
            }
        }

        private void LoadBookDetails()
        {
            int bookId;
            if (int.TryParse(Request.QueryString["BookID"], out bookId) && bookId > 0)
            {
                DatabaseConnection db = new DatabaseConnection();
                string sql = $"SELECT * FROM Books WHERE BookID = {bookId}";
                DataTable dt = db.LoadDL(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ViewState["BookID"] = bookId;
                    TitleLabel.Text = row["Title"].ToString();
                    AuthorLabel.Text = row["Author"].ToString();
                    PublisherLabel.Text = row["Publisher"].ToString();
                    PublicationYearLabel.Text = row["PublicationYear"].ToString();
                    GenreLabel.Text = row["GenreId"].ToString();
                    DescriptionLabel.Text = row["Description"].ToString();
                    CoverImage.ImageUrl = row["CoverImageUrl"].ToString();
                }
            }
        }

        protected void RentButton_Click(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Redirect to login page if the user is not authenticated
                Response.Redirect("~/Login.aspx");
                return;
            }

            int bookId = (int)ViewState["BookID"];
            int userId = GetUserId(); // Assuming you have a method to get the current user's ID

            // Add the book to the CartItems table
            DatabaseConnection db = new DatabaseConnection();
            string sql = "INSERT INTO CartItems (UserID, BookID, Quantity) VALUES (@UserID, @BookID, @Quantity)";

            using (SqlCommand cmd = new SqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                cmd.Parameters.AddWithValue("@Quantity", 1);

                db.conn.Open();
                cmd.ExecuteNonQuery();
                db.conn.Close();
            }

            // Redirect to cart page
            Response.Redirect("Cart.aspx");
        }

        private int GetUserId()
        {
            // Replace this with the actual logic to get the current user's ID
            // For example, you can query the Users table to get the UserID by User.Identity.Name
            string username = User.Identity.Name;
            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT UserID FROM Users WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                db.conn.Open();
                object result = cmd.ExecuteScalar();
                db.conn.Close();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
        }
    }
}
