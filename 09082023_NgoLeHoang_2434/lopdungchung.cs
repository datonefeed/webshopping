using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace _09082023_NgoLeHoang_2434
{
    public class lopdungchung : System.Web.UI.Page
    {
        SqlConnection SqlCon;
        public lopdungchung() { }
        public void ketnoi()
        {
            string Sql = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename="
                    + Server.MapPath("/App_Data/Database.mdf")
                    + ";Integrated Security = True";
            SqlCon = new SqlConnection(Sql);
            SqlCon.Open();
        }
        public void ngatketnoi()
        {
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }
        public DataTable fillData(string SqlCommand)
        {
            DataTable DT = new DataTable();
            try
            {
                ketnoi();
                SqlDataAdapter DA = new SqlDataAdapter(SqlCommand, SqlCon);

                DA.Fill(DT);
            }
            catch
            {
                DT = null;
            }
            finally
            {
                ngatketnoi();
            }
            return DT;
        }
        public string returnPrive(string SqlCom)
        {
            string prive = "";
            try
            {
                ketnoi();
                SqlCommand cmd = new SqlCommand(SqlCom, SqlCon);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    prive = reader.GetString(0);
                }
            }
            catch
            {
                prive = "";
            }
            finally
            {
                ngatketnoi();
            }
            return prive;
        }
        public int returnAmount(string SqlCom)
        {
            int prive = 0;
            ketnoi();
            SqlCommand cmd = new SqlCommand(SqlCom, SqlCon);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                prive = reader.GetInt32(0);
            }
            ngatketnoi();
            return prive;
        }
        public int update(string SqlCom)
        {
            int ketqua = 0;
            try
            {
                ketnoi();
                SqlCommand cmd = new SqlCommand(SqlCom, SqlCon);
                ketqua = cmd.ExecuteNonQuery();
            }
            catch
            {
                ketqua = 0;
            }
            finally
            {
                ngatketnoi();
            }
            return ketqua;
        }
    }
}