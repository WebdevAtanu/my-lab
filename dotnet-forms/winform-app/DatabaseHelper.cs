using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace winform_app
{
    public class DatabaseHelper
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBConnection"]?.ConnectionString
            ?? throw new Exception("Database connection string not found.");

        // SELECT Queries
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }

            return dt;
        }

        // INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing non-query: " + ex.Message);
            }
        }

        // COUNT, SUM, SINGLE VALUE
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing scalar query: " + ex.Message);
            }
        }
    }
}