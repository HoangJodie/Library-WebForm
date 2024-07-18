using System;
using System.Data.SqlClient;
using System.Web.Security;

namespace LibraryWebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Thuong Mai Dien Tu\Project\LibraryWebForm\LibraryWebForm\App_Data\Database.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null)
                {
                    string role = result.ToString();
                    FormsAuthentication.SetAuthCookie(username, false);

                    if (role == "Admin")
                    {
                        Response.Redirect("~/Admin.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                }
                else
                {
                    ErrorMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                }
            }
        }
    }
}
