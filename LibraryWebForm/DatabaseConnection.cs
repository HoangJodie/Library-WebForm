using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LibraryWebForm
{
    public class DatabaseConnection
    {
        string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Thuong Mai Dien Tu\Project\LibraryWebForm\LibraryWebForm\App_Data\Database.mdf"";Integrated Security=True";
        internal SqlConnection conn;
        public DatabaseConnection()
        {
            conn = new SqlConnection(chuoikn);
        }
        public int ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object LayGT(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }

        public string LayDL(string sql)
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : "Not found";
            }
        }
    }
}