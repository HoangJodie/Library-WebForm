using System;
using System.Data;
using System.Data.SqlClient;
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
                if (Request.QueryString["GenreId"] != null)
                {
                    int genreId;
                    if (int.TryParse(Request.QueryString["GenreId"], out genreId))
                    {
                        LoadBooksByGenre(genreId);
                    }
                }
                else
                {
                    LoadBooks();

                    // Kiểm tra nếu có tên sách tìm kiếm trong Session
                    if (Session["SearchText"] != null)
                    {
                        string searchText = Session["SearchText"].ToString();
                        Session["SearchText"] = null; // Xóa dữ liệu tìm kiếm sau khi hiển thị
                        SearchAndDisplayBook(searchText);
                    }
                }
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

        private void LoadBooksByGenre(int genreId)
        {
            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT BookID, Title, CoverImageUrl FROM Books WHERE GenreId = @GenreId";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@GenreId", genreId);
            db.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            StringBuilder html = new StringBuilder();
            while (reader.Read())
            {
                int bookId = (int)reader["BookID"];
                string title = reader["Title"].ToString();
                string coverImageUrl = reader["CoverImageUrl"].ToString();

                html.Append("<div class='book'>");
                html.AppendFormat("<a href='BookDetails.aspx?BookID={0}'>", bookId);
                html.AppendFormat("<img src='{0}' alt='{1}' />", coverImageUrl, title);
                html.AppendFormat("<div class='title'>{0}</div>", title);
                html.Append("</a>");
                html.Append("</div>");
            }

            db.conn.Close();
            BookContainer.InnerHtml = html.ToString();

            if (html.Length > 0)
            {
                SearchResult.InnerText = $"Danh sách các sách thuộc thể loại.";
            }
            else
            {
                SearchResult.InnerText = $"Không tìm thấy sách thuộc thể loại này.";
            }
        }

        private void SearchAndDisplayBook(string searchText)
        {
            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT BookID, Title, CoverImageUrl FROM Books WHERE Title LIKE @SearchText";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
            db.conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            StringBuilder html = new StringBuilder();
            while (reader.Read())
            {
                int bookId = (int)reader["BookID"];
                string title = reader["Title"].ToString();
                string coverImageUrl = reader["CoverImageUrl"].ToString();

                html.Append("<div class='book'>");
                html.AppendFormat("<a href='BookDetails.aspx?BookID={0}'>", bookId);
                html.AppendFormat("<img src='{0}' alt='{1}' />", coverImageUrl, title);
                html.AppendFormat("<div class='title'>{0}</div>", title);
                html.Append("</a>");
                html.Append("</div>");
            }

            db.conn.Close();
            BookContainer.InnerHtml = html.ToString();

            if (html.Length > 0)
            {
                SearchResult.InnerText = $"Kết quả tìm kiếm cho '{searchText}':";
            }
            else
            {
                SearchResult.InnerText = $"Không tìm thấy kết quả cho '{searchText}'.";
            }
        }
    }
}
