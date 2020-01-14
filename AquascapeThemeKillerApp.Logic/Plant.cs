using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class Plant : IPlant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Difficulty { get; set; }

        public Plant(int plantId, string plantName, int difficulty)
        {
            PlantId = plantId;
            PlantName = plantName;
            Difficulty = difficulty;
        }

        public Plant(PlantModel plantModel) : this(plantModel.PlantId, plantModel.PlantName, plantModel.Difficulty)
        {

        }

        public Plant(PlantStruct plantStruct) : this(plantStruct.PlantId, plantStruct.PlantName, plantStruct.Difficulty)
        {

        }

        public Plant()
        {

        }
    }
}
