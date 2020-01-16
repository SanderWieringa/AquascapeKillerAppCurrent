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
        private List<PlantStruct> _plantsInAquarium/* { get; } = new List<PlantStruct>()*/;
        private List<FishStruct> _fishInAquarium/* { get; } = new List<FishStruct>()*/;
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
            var aquascapeId = 0;

            using (GetConnection())
            {
                _conn.Open();
                var cmd = new SqlCommand("SP_GetAllAquascape", _conn) { CommandType = CommandType.StoredProcedure };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        if (aquascapeId != reader.GetInt32(0))
                        {
                            _plantsInAquarium = new List<PlantStruct>();
                            _fishInAquarium = new List<FishStruct>();
                            AquascapeStructList.Add(new AquascapeStruct(_plantsInAquarium, _fishInAquarium, reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                            aquascapeId = reader.GetInt32(0);
                        }

                        // ToDo: fill in plants and fishes
                        if (!reader.IsDBNull(7))
                        {
                            if (!_plantsInAquarium.Exists(plant => plant.PlantId == reader.GetInt32(7)))
                            {
                                _plantsInAquarium.Add(new PlantStruct(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9)));
                            }
                        }
                        if (!reader.IsDBNull(3))
                        {
                            if (!_fishInAquarium.Exists(fish => fish.FishId == reader.GetInt32(3)))
                            {
                                _fishInAquarium.Add(new FishStruct(reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
                            }
                        }

                        
                        else if (reader.GetInt32(0) > aquascapeId)
                        {
                            AquascapeStructList.Add(new AquascapeStruct(_plantsInAquarium, _fishInAquarium, reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                            aquascapeId = reader.GetInt32(0);
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
                        if (!reader.IsDBNull(7))
                        {
                            if (!_plantsInAquarium.Exists(plant => plant.PlantId == reader.GetInt32(7)))
                            {
                                _plantsInAquarium.Add(new PlantStruct(reader.GetInt32(7), reader.GetString(8),
                                    reader.GetInt32(9)));
                            }
                        }
                        if (!reader.IsDBNull(3))
                        {
                            if (!_fishInAquarium.Exists(fish => fish.FishId == reader.GetInt32(3)))
                            {
                                _fishInAquarium.Add(new FishStruct(reader.GetInt32(3), reader.GetString(4),
                                    reader.GetInt32(5), reader.GetInt32(6)));
                            }
                        }

                        if (!aquascapeRead)
                        {
                            _aquascapeStruct = new AquascapeStruct(_plantsInAquarium, _fishInAquarium, reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
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
