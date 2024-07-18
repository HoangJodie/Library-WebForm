using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebForm
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Mật khẩu và xác nhận mật khẩu không khớp.";
                return;
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Thuong Mai Dien Tu\Project\LibraryWebForm\LibraryWebForm\App_Data\Database.mdf"";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, 'User')";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                if (result > 0)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    ErrorMessage.Text = "Đã xảy ra lỗi khi đăng ký tài khoản. Vui lòng thử lại.";
                }
            }
        }
    }
}