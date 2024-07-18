using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebForm
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                int userId = GetUserId();

                DatabaseConnection db = new DatabaseConnection();
                string sql = "SELECT ci.BookID, b.Title, b.CoverImageUrl FROM CartItems ci INNER JOIN Books b ON ci.BookID = b.BookID WHERE ci.UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    db.conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    db.conn.Close();

                    CartRepeater.DataSource = dt;
                    CartRepeater.DataBind();
                }
            }
            else
            {
                // Redirect to login page if the user is not authenticated
                Response.Redirect("~/Login.aspx");
            }
        }

        private int GetUserId()
        {
            // Replace this with the actual logic to get the current user's ID
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

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int bookId = Convert.ToInt32(btn.CommandArgument);

            if (User.Identity.IsAuthenticated)
            {
                int userId = GetUserId();

                DatabaseConnection db = new DatabaseConnection();
                string sql = "DELETE FROM CartItems WHERE UserID = @UserID AND BookID = @BookID";

                using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    db.conn.Open();
                    cmd.ExecuteNonQuery();
                    db.conn.Close();
                }

                LoadCart();
            }
            else
            {
                // Redirect to login page if the user is not authenticated
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
