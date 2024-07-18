using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebForm
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGenres();

                if (Context.User.Identity.IsAuthenticated)
                {
                    LoginButton.Visible = false;
                    RegisterButton.Visible = false;
                    CartButton.Visible = true;
                    LogoutButton.Visible = true;
                }
                else
                {
                    LoginButton.Visible = true;
                    RegisterButton.Visible = true;
                    CartButton.Visible = false;
                    LogoutButton.Visible = false;
                }
            }
        }

        protected void LoadGenres()
        {
            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT GenreId, GenreName FROM Genre";
            DataTable dt = db.LoadDL(sql);

            foreach (DataRow row in dt.Rows)
            {
                int genreId = (int)row["GenreId"];
                string genreName = row["GenreName"].ToString();

                var link = new HyperLink
                {
                    Text = genreName,
                    NavigateUrl = $"~/Home.aspx?GenreId={genreId}"
                };

                GenreDropdown.Controls.Add(link);
                GenreDropdown.Controls.Add(new Literal { Text = "<br/>" });
            }
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
            Response.Redirect("~/Home.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Store search text in Session
                Session["SearchText"] = searchText;

                // Redirect to Home page
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}
