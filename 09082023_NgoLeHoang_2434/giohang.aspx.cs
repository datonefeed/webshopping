using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _09082023_NgoLeHoang_2434
{
    public partial class giohang : System.Web.UI.Page
    {
        lopdungchung ketnoi = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string sql = "select SANPHAM.MASANPHAM,TENSANPHAM,MoTa,GIA,DONHANG.SoLuong, GIA*DONHANG.SOLUONG as ThanhTien"
                    + " from SANPHAM, DONHANG"
                    + " where SANPHAM.MASANPHAM=DONHANG.MASANPHAM and TENKHACHHANG='" + tendangnhap + "'";
                GridView1.DataSource = ketnoi.fillData(sql);
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                Button bt = (Button)sender;
                string mahang = bt.CommandArgument;
                GridViewRow gr = (GridViewRow)bt.Parent.Parent;
                string soluong = ((TextBox)gr.FindControl("TextBox1")).Text;
                int soHangtonkho = ketnoi.returnAmount("select SOLUONG from SANPHAM where MASANPHAM='" + mahang + "'");
                if (soHangtonkho >= Int32.Parse(soluong))
                {
                    string sql = "update DONHANG Set SoLuong=" + soluong +
                    " where TENKHACHHANG='" + tendangnhap + "' and MASANPHAM='" + mahang + "'";
                    int kq = ketnoi.update(sql);
                    if (kq > 0)
                    {
                        GridView1.EditIndex = -1;
                        GridView1.DataBind();
                        Response.Redirect(Request.RawUrl);
                        lbthongbao.Text = "Thành công";
                    }
                    else lbthongbao.Text = "Không thành công";
                }
                else
                {
                    lbthongbao.Text = "Không đủ hàng";
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string mahang = ((LinkButton)sender).CommandArgument;
                string sql = "delete DONHANG where TENKHACHHANG='"
                    + tendangnhap + "' and MASANPHAM=" + mahang;
                int kq = ketnoi.update(sql);
                if (kq > 0)
                {
                    Response.Redirect(Request.RawUrl);
                    lbthongbao.Text = "Thành công";
                }
                else lbthongbao.Text = "Không thành công";
            }
        }

        protected void bConfirm_Click(object sender, EventArgs e)
        {
            int kq = 0;
            string tendangnhap = Session["username"] + "";
            int[] sohang;
            string[] mahang;
            int j = 0;
            string sql_dulieu = "select * from DONHANG where TENKHACHHANG='" + tendangnhap + "'";
            DataTable dt = ketnoi.fillData(sql_dulieu);
            if(dt.Rows.Count > 0)
            {
                int Rowcount = dt.Rows.Count;
                sohang = new int[Rowcount];
                mahang = new string[Rowcount];
                lbthongbao.Text = Rowcount.ToString();
                foreach (DataRow row in dt.Rows)
                {
                    mahang[j] = row.Field<string>("MASANPHAM");
                    sohang[j] = row.Field<int>("SOLUONG");
                    j ++;
                }
                for (int i=0;i < Rowcount; i++)
                {
                    sql_dulieu = "update SANPHAM SET SOLUONG = SOLUONG - " + sohang[i] +" where MASANPHAM='" + mahang[i] + "'";
                    kq = ketnoi.update(sql_dulieu);
                    if (kq == 0)
                    lbthongbao.Text = "Không thành công";
                }
                string sql = "delete DONHANG where TENKHACHHANG='"
                    + tendangnhap + "'";
                kq = ketnoi.update(sql);
                if (kq > 0)
                {
                    Response.Redirect(Request.RawUrl);
                }
                else lbthongbao.Text = "Không thành công";
            }
        }
    }
}