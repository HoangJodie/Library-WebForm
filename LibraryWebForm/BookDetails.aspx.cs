using System;
using System.Data;
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
                    GenreLabel.Text = row["Genre"].ToString();
                    DescriptionLabel.Text = row["Description"].ToString();
                    CoverImage.ImageUrl = row["CoverImageUrl"].ToString();
                }
            }
        }

        protected void RentButton_Click(object sender, EventArgs e)
        {
            int bookId = (int)ViewState["BookID"];
            // Add the book to the cart
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new DataTable();
                ((DataTable)Session["Cart"]).Columns.Add("BookID", typeof(int));
                ((DataTable)Session["Cart"]).Columns.Add("Title", typeof(string));
                ((DataTable)Session["Cart"]).Columns.Add("CoverImageUrl", typeof(string));
            }

            DataTable cart = (DataTable)Session["Cart"];
            DataRow[] existingRows = cart.Select($"BookID = {bookId}");
            if (existingRows.Length == 0)
            {
                DataRow newRow = cart.NewRow();
                newRow["BookID"] = bookId;
                newRow["Title"] = TitleLabel.Text;
                newRow["CoverImageUrl"] = CoverImage.ImageUrl;
                cart.Rows.Add(newRow);
            }

            Response.Redirect("Cart.aspx");
        }
    }
}
