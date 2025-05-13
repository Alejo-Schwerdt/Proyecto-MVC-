using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Database
    {
        private static string _connectionString = @"Miserver;Database=TiendaHardware;Trusted_Connection=True;";

        // Método para hacer una consulta SELECT
        public static int ExecuteNonQuery(string query, SqlParameter[] sqlParams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public static DataTable Select(string query, SqlParameter[] sqlParams = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }


        // Método para hacer un INSERT, UPDATE o DELETE
        public static SqlParameter[] ConvertToSqlParameters(Dictionary<string, object> parameters)
        {
            if (parameters == null) return null;

            List<SqlParameter> list = new List<SqlParameter>();
            foreach (var kvp in parameters)
            {
                list.Add(new SqlParameter(kvp.Key, kvp.Value ?? DBNull.Value));
            }
            return list.ToArray();
        }
        public static object ExecuteScalar(string query, SqlParameter[] sqlParams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

    }
}
