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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Session["username"] + "" != "")
            {
                Login1.Visible = false;
                HyperLink1.Visible = false;
            }
                string SqlCom = "select * from LOAIDODUNG";
            Dl.DataSource = ldc.fillData(SqlCom);
            Dl.DataBind();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
                string tenDN = Login1.UserName;
                string matkhau = Login1.Password;
                string sql = "select * from KHACHHANG where TENKHACHHANG='" + tenDN
                    + "' and MATKHAU='" + matkhau + "'";
                DataTable dt = ldc.fillData(sql);
                if (dt.Rows.Count > 0)
                {
                string prive = ldc.returnPrive("select MUCTRUYCAP from KHACHHANG where TENKHACHHANG='" + tenDN
                    + "' and MATKHAU='" + matkhau + "'");
                Session["username"] = tenDN;
                Session["prive"] = prive;
                if(prive=="Guest")
                Response.Redirect(Request.RawUrl);
                else if (prive == "Admin")
                {
                    Response.Redirect("admin.aspx");
                }
                else
                {

                }
                }
                else
                {
                    Login1.FailureText = "Tên và mật khẩu không đúng";
                }
   
        }

        protected void LK_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["ml"] = maloai;
            Server.Transfer("sanpham.aspx");
        }
    }
}