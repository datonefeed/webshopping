using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _09082023_NgoLeHoang_2434
{
    public partial class sanpham : System.Web.UI.Page
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string maloai = Context.Items["ml"] + "";
            string sql = "";
            if (maloai == "")
                sql = "select * from SANPHAM";
            else
                sql = "select * from SANPHAM where MALOAI='" + maloai + "'";
            dl1.DataSource = ldc.fillData(sql);
            dl1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string maloai = ((ImageButton)sender).CommandArgument;
            Response.Redirect("chitiet.aspx?ml=" + maloai);
        }


    }
}