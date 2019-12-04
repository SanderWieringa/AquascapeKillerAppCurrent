using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public class FishSqlContext : IFishContext
    {
        public List<FishStruct> FishStructList { get; } = new List<FishStruct>();
        private SqlConnection _conn;
        private const string ConnectionString = "Server=mssql.fhict.local;Database=dbi365250;User Id=dbi365250;Password=Kcw0hI3FHW;";

        private SqlConnection GetConnection()
        {
            return _conn = new SqlConnection(ConnectionString);
        }

        public List<FishStruct> GetAllFishes()
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllFish", _conn) { CommandType = CommandType.StoredProcedure };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FishStructList.Add(new FishStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
            }
            return FishStructList;
        }
    }
}
