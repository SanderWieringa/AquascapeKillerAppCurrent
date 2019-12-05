using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public class AquascapeMemoryContext : IAquascapeContext
    {
        private List<AquascapeStruct> aquascapeStructs = new List<AquascapeStruct>();
        private List<PlantStruct> plantStructs = new List<PlantStruct>();
        private List<FishStruct> fishStructs = new List<FishStruct>();

        private void PrefillAquascapeList()
        {
            aquascapeStructs.Add(new AquascapeStruct(fishStructs, plantStructs, 1, "Name", 4));
            aquascapeStructs.Add(new AquascapeStruct(fishStructs, plantStructs, 2, "Name", 4));
        }

        private void PrefillPlantList()
        {
            plantStructs.Add(new PlantStruct(1, "Echinodorus", 2));
            plantStructs.Add(new PlantStruct(2, "Red Tiger Lotus", 3));
        }

        private void PrefillFishList()
        {
            fishStructs.Add(new FishStruct(1, "AngelFish", 2, 5));
            fishStructs.Add(new FishStruct(2, "Ancistrus", 1, 5));
        }

        public void AddAquascape(AquascapeStruct aquascapeStruct)
        {
            aquascapeStructs.Add(aquascapeStruct);
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            PrefillAquascapeList();

            return aquascapeStructs;
        }

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            PrefillAquascapeList();
            AquascapeStruct aquascapeStruct = aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeId);

            return aquascapeStruct;
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public void RemoveAquascape(int aquascapeId)
        {
            AquascapeStruct aquascapeStruct = aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeId);

            aquascapeStructs.Remove(aquascapeStruct);
        }

        public void UpdateAquascape(AquascapeStruct aquascapeStruct)
        {
            AquascapeStruct aquascapeStructToUpdate = aquascapeStructs.Find(aquascape => aquascape.AquascapeId == aquascapeStruct.AquascapeId);
        }

        public List<PlantStruct> GetAllPlants()
        {
            PrefillPlantList();
            return plantStructs;
        }

        public List<FishStruct> GetAllFish()
        {
            PrefillFishList();
            return fishStructs;
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            PrefillPlantList();
            return plantStructs;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            throw new NotImplementedException();
        }
    }
}
