using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;

using System.Collections;
using System.Data.Common;

namespace FingerprintRegnition
{
    public class DbConnect
    {
        private string connectionString = @"Data Source=DESKTOP-HA8A5JN\SQLEXPRESS;Initial Catalog=QL_FingerScan;Integrated Security=True";
        private SqlConnection conn;

        public void ConnectSQL()
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Connected to SQL Server successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to SQL Server: " + ex.Message);
            }
        }

        public bool ClsKetNoi_CSDL_KiemTra()
        {
            SqlConnection con = new SqlConnection();
            string ketnoi = connectionString;

            con.ConnectionString = ketnoi; //ketnoi;
            {
                try
                {
                    //con.Open();
                    return true;
                }
                catch
                //catch (SqlException)
                {
                    return false;
                }
            }
        }

        public DataTable GetData(string sql)
        {
            ConnectSQL();
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();
            dt.Dispose();
            return dt;
        }

        public int InsertData(string sql)
        {
            ConnectSQL();
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;
            command.Dispose();
            return command.ExecuteNonQuery();
        }

        public int UpdateData(string sql)
        {
            ConnectSQL();
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;
            command.Dispose();
            return command.ExecuteNonQuery();
        }
    }
}
