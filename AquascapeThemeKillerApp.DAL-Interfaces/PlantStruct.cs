using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public struct PlantStruct
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Difficulty { get; set; }

        public PlantStruct(int plantId, string plantName, int difficulty)
        {
            PlantId = plantId;
            PlantName = plantName;
            Difficulty = difficulty;
        }
    }
}
