using System;
using System.Data;
using System.Data.SqlClient;

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
            SqlCommand command = new SqlCommand(sql, conn);
            return ThemXoaSua(command);
        }

        public int ThemXoaSua(SqlCommand command)
        {
            command.Connection = conn;
            conn.Open();
            int kq = command.ExecuteNonQuery();
            conn.Close();
            return kq;
        }

        public DataTable LoadDL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            return LoadDL(command);
        }

        public DataTable LoadDL(SqlCommand command)
        {
            command.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public object LayGT(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            return LayGT(command);
        }

        public object LayGT(SqlCommand command)
        {
            command.Connection = conn;
            conn.Open();
            object kq = command.ExecuteScalar();
            conn.Close();
            return kq;
        }

        public string LayDL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            return LayDL(command);
        }

        public string LayDL(SqlCommand command)
        {
            command.Connection = conn;
            conn.Open();
            object result = command.ExecuteScalar();
            conn.Close();
            return result != null ? result.ToString() : "Not found";
        }
    }
}
