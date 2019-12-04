using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public class AquascapeRepository : IAquascapeRepository, IAquascapeCollectionRepository
    {
        private IAquascapeContext context;

        public AquascapeRepository(IAquascapeContext context)
        {
            this.context = context;
        }

        public void UpdateAquascape(AquascapeStruct aquascapeStruct)
        {
            context.UpdateAquascape(aquascapeStruct);
        }

        public void RemoveAquascape(int aquascapeId)
        {
            context.RemoveAquascape(aquascapeId);
        }

        public void AddAquascape(AquascapeStruct aquascapeStruct)
        {
            context.AddAquascape(aquascapeStruct);
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            List<AquascapeStruct> list = new List<AquascapeStruct>();
            foreach (AquascapeStruct aquascape in context.GetAllAquascapes())
            {
                list.Add(aquascape);
            }

            return list;
        }

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            return context.GetAquascapeById(aquascapeId);
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            List<PlantStruct> list = new List<PlantStruct>();
            foreach (PlantStruct plant in context.GetAllPlantsByAquascape(aquascapeId))
            {
                list.Add(plant);
            }
            return list;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            List<FishStruct> list = new List<FishStruct>();
            foreach (FishStruct fish in context.GetAllFishByAquascape(aquascapeId))
            {
                list.Add(fish);
            }
            return list;
        }
    }
}
