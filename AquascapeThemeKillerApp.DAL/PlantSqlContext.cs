using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public class PlantSqlContext : IPlantContext
    {
        public List<PlantStruct> PlantStructList { get; } = new List<PlantStruct>();
        private SqlConnection _conn;
        private const string ConnectionString = "Server=mssql.fhict.local;Database=dbi365250;User Id=dbi365250;Password=Kcw0hI3FHW;";

        private SqlConnection GetConnection()
        {
            return _conn = new SqlConnection(ConnectionString);
        }

        public List<PlantStruct> GetAllPlants()
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllPlants", _conn) { CommandType = CommandType.StoredProcedure };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PlantStructList.Add(new PlantStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
            }
            return PlantStructList;
        }

        public void AddPlant(PlantStruct plantStruct)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_AddPlant", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@name", plantStruct.PlantName);
                cmd.Parameters.AddWithValue("@difficulty", plantStruct.Difficulty);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }


    }
}
