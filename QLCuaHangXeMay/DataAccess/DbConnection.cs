using System;
using System.Data;
using System.Data.SqlClient;

namespace QLCuaHangXeMay.DataAccess
{
    class DbConnection
    {
        SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-IS78AAG;Initial Catalog=CuaHangXeMay;Integrated Security=True");
        SqlDataAdapter _dap;
        SqlCommand _cmd;
        public DataTable table_Select(String sql)
        {
            _conn.Open();
            _dap = new SqlDataAdapter(sql, _conn);
            DataTable table = new DataTable();
            _dap.Fill(table);
            _conn.Close();
            return table;
        }
        public void table_Command(String sql)
        {
            _conn.Open();
            _cmd = new SqlCommand(sql, _conn);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _conn.Close();
        }
        public int table_Reader(String sql)
        {
            _conn.Open();
            _cmd = new SqlCommand(sql, _conn);
            SqlDataReader dr;
            dr = _cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            return count;
        }
    }
}
