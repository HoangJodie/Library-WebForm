using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace LibraryWebForm
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                // Redirect to search results page or handle search functionality
                Response.Redirect($"~/SearchResults.aspx?q={searchText}");
            }
        }
    }
}
