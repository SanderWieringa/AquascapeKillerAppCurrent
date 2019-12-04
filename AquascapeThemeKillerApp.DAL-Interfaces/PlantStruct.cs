using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public struct PlantStruct
    {
        public int PlantId { get; private set; }
        public string PlantName { get; private set; }
        public int Difficulty { get; private set; }

        public PlantStruct(int plantId, string plantName, int difficulty)
        {
            PlantId = plantId;
            PlantName = plantName;
            Difficulty = difficulty;
        }
    }
}
