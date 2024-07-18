using System;
using System.Data;
using System.Text;
using System.Web.UI;

namespace LibraryWebForm
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBooks();
            }
        }

        private void LoadBooks()
        {
            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT BookID, Title, CoverImageUrl FROM Books";
            DataTable dt = db.LoadDL(sql);

            StringBuilder html = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                int bookId = (int)row["BookID"];
                string title = row["Title"].ToString();
                string coverImageUrl = row["CoverImageUrl"].ToString();

                html.Append("<div class='book'>");
                html.AppendFormat("<a href='BookDetails.aspx?BookID={0}'>", bookId);  
                html.AppendFormat("<img src='{0}' alt='{1}' />", coverImageUrl, title);
                html.AppendFormat("<div class='title'>{0}</div>", title);
                html.Append("</a>");
                html.Append("</div>");
            }

            BookContainer.InnerHtml = html.ToString();
        }
    }
}
