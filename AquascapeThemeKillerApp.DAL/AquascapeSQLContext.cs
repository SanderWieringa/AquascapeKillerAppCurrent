using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    //public enum FishType
    //{
    //    Herbivore,
    //    Carnivore
    //}

    //public enum FishSize
    //    small = 1,
    //    medium = 3,
    //    big = 5
    //}

    public class AquascapeSQLContext : IAquascapeContext
    {
        private AquascapeStruct AquascapeStruct;
        public List<PlantStruct> PlantsInAquarium { get; } = new List<PlantStruct>();
        public List<FishStruct> FishInAquarium { get; } = new List<FishStruct>();
        public List<AquascapeStruct> AquascapeStructList { get; } = new List<AquascapeStruct>();
        private SqlConnection _conn;
        private const string ConnectionString = "Server=mssql.fhict.local;Database=dbi365250;User Id=dbi365250;Password=Kcw0hI3FHW;";

        private SqlConnection GetConnection()
        {
            return _conn = new SqlConnection(ConnectionString);
        }

        public void UpdateAquascape(AquascapeStruct aquascapeStruct)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_UpdateAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeStruct.AquascapeId);
                cmd.Parameters.AddWithValue("@name", aquascapeStruct.Name);
                cmd.Parameters.AddWithValue("@difficulty", aquascapeStruct.Difficulty);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }

        public void RemoveAquascape(int aquascapeId)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_RemoveAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }

        public void AddAquascape(AquascapeStruct aquascapeStruct)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_AddAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@name", aquascapeStruct.Name);
                cmd.Parameters.AddWithValue("@difficulty", aquascapeStruct.Difficulty);
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AquascapeStructList.Add(new AquascapeStruct(null, null, reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
            }
            return AquascapeStructList;
        }

        //public AquascapeStruct GetAquascapeById(int aquascapeId)
        //{
        //    AquascapeStruct aquascapestruct = new AquascapeStruct(GetAllFishByAquascape(aquascapeId), GetAllPlantsByAquascape(aquascapeId), GetAquascapeWithoutListById(aquascapeId).AquascapeId, GetAquascapeWithoutListById(aquascapeId).Name, GetAquascapeWithoutListById(aquascapeId).Difficulty);
        //    return aquascapestruct;
        //}

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            var aquascapeRead = false;

            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAquascapeById", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!PlantsInAquarium.Exists(plant => plant.PlantId == reader.GetInt32(7)))
                        {
                            PlantsInAquarium.Add(new PlantStruct(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9)));
                        }

                        if (!FishInAquarium.Exists(fish => fish.FishId == reader.GetInt32(3)))
                        {
                            FishInAquarium.Add(new FishStruct(reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
                        }

                        if (!aquascapeRead)
                        {
                            AquascapeStruct = new AquascapeStruct(PlantsInAquarium, FishInAquarium, reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                            aquascapeRead = true;
                        }
                    }
                }
            }
            return AquascapeStruct;
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllPlantsInAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PlantsInAquarium.Add(new PlantStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
            }
            return PlantsInAquarium;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("[SP_GetAllFishInAquascape]", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FishInAquarium.Add(new FishStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
            }
            return FishInAquarium;
        }
    }
}
