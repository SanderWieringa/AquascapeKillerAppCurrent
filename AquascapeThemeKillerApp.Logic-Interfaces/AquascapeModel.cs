using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public class AquascapeModel
    {
        public List<IPlant> PlantsInAquarium { get; set; }
        public List<IFish> FishInAquarium { get; set; }
        public int AquascapeId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public AquascapeModel(List<IPlant> plantsInAquarium, List<IFish> fishInAquarium, int aquascapeId, string name, int difficulty)
        {
            PlantsInAquarium = plantsInAquarium;
            FishInAquarium = fishInAquarium;
            AquascapeId = aquascapeId;
            Name = name;
            Difficulty = difficulty;
        }

        public AquascapeModel(IAquascape aquascape) : this(aquascape.PlantsInAquarium, aquascape.FishInAquarium, aquascape.AquascapeId, aquascape.Name, aquascape.Difficulty)
        {

        }

        public AquascapeModel()
        {

        }
    }
}
