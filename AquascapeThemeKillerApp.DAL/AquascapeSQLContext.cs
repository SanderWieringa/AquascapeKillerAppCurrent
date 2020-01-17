using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public class AquascapeSQLContext : IAquascapeContext
    {
        private AquascapeStruct _aquascapeStruct;
        private List<PlantStruct> _plantsInAquarium;
        private List<FishStruct> _fishInAquarium;
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
                var cmd = new SqlCommand("SP_InsertAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@AquascapeName", aquascapeStruct.Name);
                cmd.Parameters.AddWithValue("@aquascapeDifficulty", aquascapeStruct.Difficulty);
                foreach (PlantStruct plant in aquascapeStruct.PlantsInAquarium)
                {
                    cmd.Parameters.AddWithValue("@plantId", plant.PlantId);
                }

                foreach (FishStruct fish in aquascapeStruct.FishInAquarium)
                {
                    cmd.Parameters.AddWithValue("@fishId", fish.FishId);
                }
                cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            var aquascapeId = 0;

            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (aquascapeId != Convert.ToInt32(reader["aquascapeId"]))
                        {
                            _plantsInAquarium = new List<PlantStruct>();
                            _fishInAquarium = new List<FishStruct>();
                            AquascapeStructList.Add(new AquascapeStruct(_plantsInAquarium, _fishInAquarium, Convert.ToInt32(reader["aquascapeId"]), reader["aquascapeName"].ToString(), Convert.ToInt32(reader["aquascapeDifficulty"])));
                            aquascapeId = Convert.ToInt32(reader["aquascapeId"]);
                        }

                        // ToDo: fill in plants and fishes
                        // column index 7 is plantId
                        if (!reader.IsDBNull(7))
                        {
                            if (!_plantsInAquarium.Exists(plant => plant.PlantId == Convert.ToInt32(reader["plantId"])))
                            {
                                _plantsInAquarium.Add(new PlantStruct(Convert.ToInt32(reader["plantId"]), reader["plantName"].ToString(), Convert.ToInt32(reader["plantDifficulty"])));
                            }
                        }
                        // column index 3 is fishId
                        if (!reader.IsDBNull(3))
                        {
                            if (!_fishInAquarium.Exists(fish => fish.FishId == Convert.ToInt32(reader["fishId"])))
                            {
                                _fishInAquarium.Add(new FishStruct(Convert.ToInt32(reader["fishId"]), reader["fishName"].ToString(), Convert.ToInt32(reader["fishType"]), Convert.ToInt32(reader["fishSize"])));
                            }
                        }
                    }
                }
            }
            return AquascapeStructList;
        }

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            var aquascapeRead = false;

            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAquascapeById", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);

                _plantsInAquarium = new List<PlantStruct>();
                _fishInAquarium = new List<FishStruct>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // column index 7 is plantId
                        if (!reader.IsDBNull(7))
                        {
                            if (!_plantsInAquarium.Exists(plant => plant.PlantId == Convert.ToInt32(reader["plantId"])))
                            {
                                _plantsInAquarium.Add(new PlantStruct(Convert.ToInt32(reader["plantId"]), reader["plantName"].ToString(),
                                    Convert.ToInt32(reader["plantDifficulty"])));
                            }
                        }
                        // column index 3 is fishId
                        if (!reader.IsDBNull(3))
                        {
                            if (!_fishInAquarium.Exists(fish => fish.FishId == Convert.ToInt32(reader["fishId"])))
                            {
                                _fishInAquarium.Add(new FishStruct(Convert.ToInt32(reader["fishId"]), reader["fishName"].ToString(),
                                    Convert.ToInt32(reader["fishType"]), Convert.ToInt32(reader["fishSize"])));
                            }
                        }

                        if (!aquascapeRead)
                        {
                            _aquascapeStruct = new AquascapeStruct(_plantsInAquarium, _fishInAquarium, Convert.ToInt32(reader["aquascapeId"]), reader["aquascapeName"].ToString(), Convert.ToInt32(reader["aquascapeDifficulty"]));
                            aquascapeRead = true;
                        }
                    }
                }
            }
            return _aquascapeStruct;
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            _plantsInAquarium = new List<PlantStruct>();
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllPlantsInAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _plantsInAquarium.Add(new PlantStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
            }
            return _plantsInAquarium;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            _fishInAquarium = new List<FishStruct>();
            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("[SP_GetAllFishInAquascape]", _conn) { CommandType = CommandType.StoredProcedure };
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@aquascapeId", aquascapeId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _fishInAquarium.Add(new FishStruct(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
            }
            return _fishInAquarium;
        }
    }
}
