using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Models
{
    public class PlantViewModel
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Difficulty { get; set; }

        public List<PlantModel> PlantList = new List<PlantModel>();

        public PlantViewModel()
        {
            
        }

        public PlantViewModel(List<PlantModel> plantList)
        {
            PlantList = plantList;
        }
    }
}
