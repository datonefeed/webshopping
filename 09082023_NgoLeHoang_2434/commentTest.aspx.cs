using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _09082023_NgoLeHoang_2434
{
    public partial class commentTest : System.Web.UI.Page
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int kq = 0;
            string sql = "insert into Comment values(N'" + name.Text + "', N'" + email.Text + "', N'" + comment.InnerText.Trim() + "')";
            kq = ldc.update(sql);
            if (kq == 0)
                lbthongbao.Text = "FAIL";
            else
                lbthongbao.Text = "SUCCESS";


        }
    }
}