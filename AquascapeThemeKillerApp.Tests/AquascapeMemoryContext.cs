using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;

namespace AquascapeThemeKillerApp.DAL
{
    public class AquascapeMemoryContext : IAquascapeContext
    {
        private readonly List<AquascapeStruct> _aquascapeStructs = new List<AquascapeStruct>();
        private readonly List<PlantStruct> _plantStructs = new List<PlantStruct>();
        private readonly List<FishStruct> _fishStructs = new List<FishStruct>();
        private readonly AquascapeStruct _aquascape = new AquascapeStruct(new List<PlantStruct>(), new List<FishStruct>(), 0, "", 0);

        private void PrefillAquascapeList()
        {
            _aquascapeStructs.Add(new AquascapeStruct(_plantStructs, _fishStructs, 1, "Name", 4));
            _aquascapeStructs.Add(new AquascapeStruct(_plantStructs, _fishStructs, 2, "Name", 4));
        }

        private void PrefillAquascapePlantList()
        {
            _aquascape.PlantsInAquarium.Add(new PlantStruct(1, "Echinodorus", 2));
            _aquascape.PlantsInAquarium.Add(new PlantStruct(2, "Red Tiger Lotus", 3));
        }

        private void PrefillAquascapeFishList()
        {
            _aquascape.FishInAquarium.Add(new FishStruct(1, "AngelFish", 2, 5));
            _aquascape.FishInAquarium.Add(new FishStruct(2, "Ancistrus", 1, 5));
        }

        private void PrefillPlantList()
        {
            _plantStructs.Add(new PlantStruct(1, "Echinodorus", 2));
            _plantStructs.Add(new PlantStruct(2, "Red Tiger Lotus", 3));
        }

        private void PrefillFishList()
        {
            _fishStructs.Add(new FishStruct(1, "AngelFish", 2, 5));
            _fishStructs.Add(new FishStruct(2, "Ancistrus", 1, 5));
        }

        public void AddAquascape(AquascapeStruct aquascapeStruct)
        {
            _aquascapeStructs.Add(aquascapeStruct);
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            PrefillAquascapeList();

            return _aquascapeStructs;
        }

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            PrefillAquascapeList();
            var aquascapeStruct = _aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeId);

            return aquascapeStruct;
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public void RemoveAquascape(int aquascapeId)
        {
            var aquascapeStruct = _aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeId);

            _aquascapeStructs.Remove(aquascapeStruct);
        }

        public void UpdateAquascape(AquascapeStruct aquascapeStruct)
        {
            var aquascapeStructToUpdate = _aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeStruct.AquascapeId);
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            PrefillAquascapeList();
            var aquascape = _aquascapeStructs.Find(x => x.AquascapeId == aquascapeId);
            aquascape.PlantsInAquarium.Add(new PlantStruct(1, "Red Tiger Lotus", 3));
            aquascape.PlantsInAquarium.Add(new PlantStruct(2, "Echinodorus Ozelot", 2));
            return aquascape.PlantsInAquarium;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            PrefillAquascapeList();
            var aquascape = _aquascapeStructs.Find(x => x.AquascapeId == aquascapeId);
            aquascape.FishInAquarium.Add(new FishStruct(1, "AngelFish", 2 , 5));
            aquascape.FishInAquarium.Add(new FishStruct(2, "Tetra", 3, 1));
            return aquascape.FishInAquarium;
        }
    }
}
