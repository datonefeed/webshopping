using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace _09082023_NgoLeHoang_2434
{
    public partial class registerPage : System.Web.UI.Page
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string tenDN = TextBox1.Text;
                string matkhau = TextBox2.Text;
                string sql = "select * from KHACHHANG where TENKHACHHANG='" + tenDN
                    + "'";
                DataTable dt = ldc.fillData(sql);
                if (dt.Rows.Count > 0)
                {
                    Label1.Text = "Account already existed";
                }
                else
                {
                    sql = "insert into KHACHHANG values('"
                    + tenDN + "','" + matkhau + "','Guest') ";


                    int kq = ldc.update(sql);
                    if (kq > 0)
                    {
                        Label1.Text = "Success";
                        Button2.Visible = true;
                    }
                    else Label1.Text = "Failed";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("sanpham.aspx");
        }
    }
}