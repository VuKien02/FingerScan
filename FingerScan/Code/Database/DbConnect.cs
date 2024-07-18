﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;

using System.Collections;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;

namespace FingerprintRegnition.Database
{
    public class DbConnect
    {
        SqlConnection con = new SqlConnection();

        string ketnoi = @"Data Source=DESKTOP-L4ENP6U;Initial Catalog=QL_FingerScan;Integrated Security=True";

        public bool ClsKetNoi_CSDL_KiemTra()
        {

            SqlConnection con = new SqlConnection();
            //string ketnoi = ConfigurationManager.ConnectionStrings["project"].ConnectionString;

            con.ConnectionString = ketnoi; //ketnoi;
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public DbConnect()
        {

            if (IsServerConnected() == false)
            {
                Close();
                Application.Exit();
            }

        }

        public bool IsServerConnected()
        {
            con.ConnectionString = ketnoi + ";pooling=true;Max Pool Size=9999;MultipleActiveResultSets=True"; //ketnoi;
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public void Close()
        {
            con.Dispose();
        }
        public DataTable LayDuLieu(string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();
            dt.Dispose();
            return dt;
        }
        public DataTable LayDuLieu(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < Nparameter; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();
            dt.Dispose();
            return dt;
        }
        public SqlDataReader LayDuLieu_R(string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            command.Dispose();
            return command.ExecuteReader();
        }

        public SqlDataReader LayDuLieu_R(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < Nparameter; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            command.Dispose();
            return command.ExecuteReader();
        }
        public int LayDuLieu_Count(string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();
            dt.Dispose();
            return dt.Rows.Count;
        }

        public int LayDuLieu_Count(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < Nparameter; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();
            dt.Dispose();
            return dt.Rows.Count;
        }
        public int Update(string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            command.Dispose();
            return command.ExecuteNonQuery();
        }
        public int Update(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < Nparameter; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            command.Dispose();
            return command.ExecuteNonQuery();
        }
        public int Edit(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < Nparameter; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            command.Dispose();
            return command.ExecuteNonQuery();
        }
    }
}
