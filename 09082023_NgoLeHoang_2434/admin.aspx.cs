using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace _09082023_NgoLeHoang_2434
{
    public partial class admin : System.Web.UI.Page
    {
        lopdungchung ldc = new lopdungchung();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;
            string sql = "";
            string prive = Session["prive"] + "";
            if (prive == "Admin")
            {
                sql = "select * from SANPHAM";
                ProductsListView.DataSource = ldc.fillData(sql);
                ProductsListView.DataBind();
            }
            else
            {
                Response.Redirect("sanpham.aspx");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (l11.Visible == false)
            {
                l11.Visible = true;
                t11.Visible = true;
                l12.Visible = true;
                t12.Visible = true;
                b1.Visible = true;
            }
            else
            {
                l11.Visible = false;
                t11.Visible = false;
                l12.Visible = false;
                t12.Visible = false;
                b1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (l21.Visible == false)
            {
                l21.Visible = true;
                t21.Visible = true;
                l22.Visible = true;
                t22.Visible = true;
                b2.Visible = true;
            }
            else
            {
                l21.Visible = false;
                t21.Visible = false;
                l22.Visible = false;
                t22.Visible = false;
                b2.Visible = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (l31.Visible == false)
            {
                l31.Visible = true;
                t31.Visible = true;
                l32.Visible = true;
                t32.Visible = true;
                l33.Visible = true;
                t33.Visible = true;
                l34.Visible = true;
                t34.Visible = true;
                l35.Visible = true;
                FileUpload1.Visible = true;
                l36.Visible = true;
                t36.Visible = true;
                l37.Visible = true;
                t37.Visible = true;
                b3.Visible = true;
            }
            else
            {
                l31.Visible = false;
                t31.Visible = false;
                l32.Visible = false;
                t32.Visible = false;
                l33.Visible = false;
                t33.Visible = false;
                l34.Visible = false;
                t34.Visible = false;
                l35.Visible = false;
                FileUpload1.Visible = false;
                l36.Visible = false;
                t36.Visible = false;
                l37.Visible = false;
                t37.Visible = false;
                b3.Visible = false;
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string ml = t11.Text;
            string tensp = t12.Text;
            string sql = "select * from LOAIDODUNG where MALOAI='" + ml
                + "' or TENLOAI='" + tensp + "'";
            DataTable dt = ldc.fillData(sql);
            if (dt.Rows.Count > 0)
            {
                lbthongbao.Text = "Type already existed";
            }
            else
            {
                sql = "insert into LOAIDODUNG values('"
                + ml + "',N'" + tensp + "') ";
                int kq = ldc.update(sql);
                if (kq > 0)
                {
                    lbthongbao.Text = "Success";
                }
                else lbthongbao.Text = "Failed";
            }
            dt.Clear();
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            string ml = t21.Text;
            string sl = t22.Text;
            int result = Int32.Parse(sl);
            if ((result > 0) && (result > 100))
            {
                string sql = "select * from SANPHAM where MASANPHAM='" + ml + "'";
                DataTable dt = ldc.fillData(sql);
                if (dt.Rows.Count > 0)
                {
                    sql = "update SANPHAM set SOLUONG=SOLUONG+" + sl + " where MASANPHAM=" + ml;
                    int kq = ldc.update(sql);
                    if (kq > 0)
                    {
                        lbthongbao.Text = "Success";
                        sql = "select * from SANPHAM";
                        ProductsListView.DataSource = ldc.fillData(sql);
                        ProductsListView.DataBind();
                    }
                    else lbthongbao.Text = "Failed";
                }
                else
                {
                    lbthongbao.Text = "Item don't exist";
                }
                dt.Clear();
            }
            else
            {
                lbthongbao.Text = "Please Input Item amount";
            }
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            {
                if (FileUpload1.HasFile)
                {
                    string str = FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Image/" + str));
                    string ha = "Image/" + str.ToString();
                    lbthongbao.Text = "Image Uploaded";
                    string maSP = t31.Text;
                    string tenSP = t32.Text;
                    string mt = t33.Text;
                    string gia = t34.Text; ;
                    string ml = t36.Text;
                    string sl = t37.Text;
                    string sql = "select * from SANPHAM where MASANPHAM='" + ml + "' or TENSANPHAM='"
                        + tenSP + "'";
                    DataTable dt = ldc.fillData(sql);
                    if (dt.Rows.Count > 0)
                    {
                        lbthongbao.Text = "Item already existed";
                    }
                    else
                    {
                        sql = "insert into SANPHAM values(N'"
                        + maSP + "',N'" + tenSP + "',N'" + mt + "'," + gia + ",N'" + ha + "',N'" + ml + "'," + sl + ")";

                        int kq = ldc.update(sql);
                        if (kq > 0)
                        {
                            lbthongbao.Text = "Success";
                            sql = "select * from SANPHAM";
                            ProductsListView.DataSource = ldc.fillData(sql);
                            ProductsListView.DataBind();
                        }
                        else lbthongbao.Text = "Failed";
                    }
                    dt.Clear();
                }

                else
                {
                    lbthongbao.Text = "Please Upload your Image";
                }
            }
        }

        protected void ProductsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tendangnhap = Session["prive"] + "";
            if (tendangnhap == "Admin")
            {
                string mahang = ((Button)sender).CommandArgument;
                string sql = "delete SANPHAM where MASANPHAM='" + mahang + "'";
                int kq = ldc.update(sql);
                if (kq > 0)
                {
                    Response.Redirect(Request.RawUrl);
                    lbthongbao.Text = "Thành công";
                    ProductsListView.DataSource = ldc.fillData(sql);
                    ProductsListView.DataBind();
                }
                else lbthongbao.Text = "Không thành công";
            }
        }
    }
}