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
