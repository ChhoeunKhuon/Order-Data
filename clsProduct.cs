using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    internal class clsProduct
    {
        //Properties of ProClass
        public int Code { get; set; }
        public string ProName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        // GetData()
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tblProduct", clsConnection.con);
            dt.Clear();
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        // Insert Data()
        public bool Insert()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand("Insert Into tblProduct(Code,ProName,Qty,Price)" +
                "Values(@Code,@ProName,@Qty,@Price)",clsConnection.con);
            cmd.Parameters.AddWithValue("@Code",Code);
            cmd.Parameters.AddWithValue("@ProName",ProName);
            cmd.Parameters.AddWithValue("@Qty",Qty);
            cmd.Parameters.AddWithValue("@Price",Price);

            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {

                check = false;
            }
            return check;
        }
        // Delete Data()  Method
        public bool Delete()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"Delete From tblProduct Where Code=@Code", clsConnection.con);
            cmd.Parameters.AddWithValue("@Code", Code);
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            return check;
        }
        public DataTable Search(string q)
        {
            DataTable dt = new DataTable();
            string sql = "Select * From tblProduct Where ProName like '%'+ @q +'%' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, clsConnection.con);
            da.SelectCommand.Parameters.AddWithValue("@q", q);
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }
        public bool Update()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"Update tblProduct
                                              Set ProName = @ProName,
                                                  Qty = @Qty,
                                                  Price=@Price
                                               Where Code=@Code", clsConnection.con);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@ProName", ProName);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Price", Price);
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            }
            return check;
        }
    }
}
