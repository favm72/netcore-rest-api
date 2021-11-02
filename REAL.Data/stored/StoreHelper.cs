using REAL.Data.generated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace REAL.Data.stored
{
    public static class StoreHelper
    {
        public static List<T> Raw<T>(this MyContext context, string query, Func<DbDataReader, T> map)
        {
            using (var conn = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                conn.Open();
                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();
                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }
                    return entities;
                }
            }
        }

        public static DataTable RawTable(this MyContext context, string query)
        {
            using (var conn = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);

                if (ds.Tables.Count == 0)
                    throw new Exception("Error al cargar tabla");

                return ds.Tables[0];
            }
        }
    }   
}
