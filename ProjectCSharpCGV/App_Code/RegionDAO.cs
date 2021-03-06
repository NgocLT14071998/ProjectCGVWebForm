﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace ProjectCSharpCGV.App_Code
{
    public  class RegionDAO
    {
        public static SqlConnection getConnection()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings["connectDB"].ToString();
            return new SqlConnection(stringConnection);
        }

        public static DataTable ReadDataBySQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, getConnection());
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cmd.Connection.Close();
            return dt;
        }
        public static DataTable ReadDataBySQLWithParameter(string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, getConnection());
            cmd.Parameters.AddRange(parameters);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cmd.Connection.Close();
            return dt;
        }

        public static bool CUDDataBySQL(string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, getConnection());
            cmd.Parameters.AddRange(parameters);
            cmd.Connection.Open();
            int numberAccess = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return numberAccess != 0;
        }
        public static DataTable getAllRegion()
        {
            string sql = "SELECT * FROM dbo.KhuVuc";
            return ReadDataBySQL(sql);
        }
    }
}