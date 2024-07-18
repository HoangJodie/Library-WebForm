using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebForm
{
    public partial class Cart : System.Web.UI.Page
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
            if (Session["Cart"] != null)
            {
                CartRepeater.DataSource = (DataTable)Session["Cart"];
                CartRepeater.DataBind();
            }
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int bookId = Convert.ToInt32(btn.CommandArgument);

            if (Session["Cart"] != null)
            {
                DataTable cart = (DataTable)Session["Cart"];
                DataRow[] rows = cart.Select($"BookID = {bookId}");
                if (rows.Length > 0)
                {
                    cart.Rows.Remove(rows[0]);
                    LoadCart();
                }
            }
        }
    }
}