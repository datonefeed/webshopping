using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace _09082023_NgoLeHoang_2434
{
    public partial class chitiet : System.Web.UI.Page
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string mahang = Request.QueryString["ml"] + "";
            if (mahang != "")
            {
                string sql = "select * from SANPHAM where MASANPHAM=" + mahang;
                Dl_chitiet.DataSource = ldc.fillData(sql);
                Dl_chitiet.DataBind();
                sql = "select * from COMMENT where MASANPHAM = " + mahang;
                Repeater1.DataSource = ldc.fillData(sql);
                Repeater1.DataBind();

            }
            else
            {
                lbthongbao.Text = "Sản phẩm không tồn tại";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tendangnhap = Session["username"] + "";
            if (tendangnhap != "")
            {
                string maloai = ((Button)sender).CommandArgument;

                Button bt_mua = (Button)sender;
                DataListItem item = (DataListItem)bt_mua.Parent;
                TextBox txtSL = (TextBox)item.FindControl("txtsoluong");
                string soluong = txtSL.Text;
                int soHangtonkho = ldc.returnAmount("select SOLUONG from SANPHAM where MASANPHAM='" + maloai +"'");
                DataTable check = ldc.fillData("select SOLUONG from " +
                    "DONHANG where MASANPHAM='" + maloai + "' " +
                    "and TENKHACHHANG = '" + tendangnhap + "'");
                int soHangDaMua = 0;
                if (check.Rows.Count > 0)
                {
                    soHangDaMua = ldc.returnAmount("select SOLUONG from DONHANG where MASANPHAM='" + maloai + "' " +
"and TENKHACHHANG = '" + tendangnhap + "'");
                }
                if (soHangtonkho >= (Int32.Parse(soluong)+soHangDaMua))
                {
                    string sql_dulieu = "select * from DONHANG where MASANPHAM='" + maloai
    + "' and TENKHACHHANG='" + tendangnhap + "'";
                    DataTable dt = ldc.fillData(sql_dulieu);
                    string sql = "";
                    if (dt.Rows.Count > 0)
                    {

                        sql = "update DONHANG Set SOLUONG=SOLUONG + " + soluong
                            + " where TENKHACHHANG='" + tendangnhap + "' and MASANPHAM='" + maloai + "'";
                    }
                    else
                    {

                        sql = "insert into DONHANG values('"
                        + maloai + "','" + tendangnhap + "'," + soluong + ") ";
                    }


                    int kq = ldc.update(sql);
                    if (kq > 0)
                    {
                        lbthongbao.Text = "Thành công";
                        sql = "select * from SANPHAM where MASANPHAM=" + maloai;
                        Dl_chitiet.DataSource = ldc.fillData(sql);
                        Dl_chitiet.DataBind();
                    }
                    else lbthongbao.Text = "Không thành công";
                }
                else if(soHangtonkho < Int32.Parse(soluong))
                {
                    lbthongbao.Text = "Không đủ hàng trong kho";
                }
                else
                {
                    lbthongbao.Text = "Bạn đã mua quá nhiều!";
                    Label HangMua = (Label)item.FindControl("Label5");
                    HangMua.Text += soHangDaMua.ToString();
                    HangMua.Visible = true;
                }
            }
            else
            {
                lbthongbao.Text = "Bạn phải đăng nhập";
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            Response.Redirect("giohang.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Session["username"] + "";
            if (name != "")
            {
                int kq = 0;
                string mahang = Request.QueryString["ml"] + "";
                string sql = "select * from Comment where TENKHACHHANG='" + name
                    + "' and MASANPHAM='" + mahang + "'";
                DataTable dt = ldc.fillData(sql);
                if (dt.Rows.Count > 0)
                {
                    sql = "update Comment set Comment = N'" + comment.InnerText.Trim() + "' where TENKHACHHANG = '" + name + "'"
                        + "and MASANPHAM='" + mahang + "'";
                    kq = ldc.update(sql);
                    if (kq > 0)
                    {
                        lbthongbao.Text = "SUCCESS";
                        sql = "select * from COMMENT where MASANPHAM = " + mahang;
                        Repeater1.DataSource = ldc.fillData(sql);
                        Repeater1.DataBind();
                    }
                    else
                        lbthongbao.Text = "FAIL";
                }
                else
                {
                    sql = "insert into Comment values(N'" + name + "', N'" + mahang + "', N'" + comment.InnerText.Trim() + "')";
                    kq = ldc.update(sql);
                    if (kq > 0)
                    {
                        lbthongbao.Text = "SUCCESS";
                        sql = "select * from COMMENT where MASANPHAM = " + mahang;
                        Repeater1.DataSource = ldc.fillData(sql);
                        Repeater1.DataBind();
                    }
                    else
                        lbthongbao.Text = "FAIL";
                }
                dt.Clear();
            }
            else lbthongbao.Text = "Bạn phải đăng nhập";
        }
    }
}