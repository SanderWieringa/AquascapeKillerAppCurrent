using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public class AquascapeRepository : IAquascapeRepository, IAquascapeCollectionRepository
    {
        private IAquascapeContext _context;

        public AquascapeRepository(IAquascapeContext context)
        {
            _context = context;
        }

        public void UpdateAquascape(AquascapeStruct aquascapeStruct)
        {
            _context.UpdateAquascape(aquascapeStruct);
        }

        public void RemoveAquascape(int aquascapeId)
        {
            _context.RemoveAquascape(aquascapeId);
        }

        public void AddAquascape(AquascapeStruct aquascapeStruct)
        {
            _context.AddAquascape(aquascapeStruct);
        }

        public List<AquascapeStruct> GetAllAquascapes()
        {
            List<AquascapeStruct> list = new List<AquascapeStruct>();
            foreach (AquascapeStruct aquascape in _context.GetAllAquascapes())
            {
                list.Add(aquascape);
            }

            return list;
        }

        public AquascapeStruct GetAquascapeById(int aquascapeId)
        {
            return _context.GetAquascapeById(aquascapeId);
        }

        public AquascapeStruct GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        public List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId)
        {
            List<PlantStruct> list = new List<PlantStruct>();
            foreach (PlantStruct plant in _context.GetAllPlantsByAquascape(aquascapeId))
            {
                list.Add(plant);
            }
            return list;
        }

        public List<FishStruct> GetAllFishByAquascape(int aquascapeId)
        {
            List<FishStruct> list = new List<FishStruct>();
            foreach (FishStruct fish in _context.GetAllFishByAquascape(aquascapeId))
            {
                list.Add(fish);
            }
            return list;
        }
    }
}
