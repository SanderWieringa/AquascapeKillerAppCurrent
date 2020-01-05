using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquascapeThemeKillerApp.Models
{
    public class AssembleAquascapeViewModel
    {
        public List<PlantModel> AllPlants { get; } = new List<PlantModel>();
        public List<FishModel> Allfishes { get; } = new List<FishModel>();

        public AssembleAquascapeViewModel()
        {

        }

        public AssembleAquascapeViewModel(List<PlantModel> allPlants, List<FishModel> allFishes)
        {
            AllPlants = allPlants;
            Allfishes = allFishes;
        }
    }
}
