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
            throw new NotImplementedException();
        }
    }
}
