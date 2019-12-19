using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public class FishRepository : IFishCollectionRepository
    {
        private readonly IFishContext _context;

        public FishRepository(IFishContext context)
        {
            _context = context;
        }

        public void AddFish(FishStruct fishStruct)
        {
            _context.AddFish(fishStruct);
        }

        public void DeleteFish(int fishId)
        {
            _context.DeleteFish(fishId);
        }

        public List<FishStruct> GetAllFishes()
        {
            List<FishStruct> fishList = new List<FishStruct>();
            foreach (var fish in _context.GetAllFishes())
            {
                fishList.Add(fish);
            }

            return fishList;
        }
    }
}
