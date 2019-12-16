using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.Tests
{
    public class FishMemoryContext : IFishContext
    {
        private readonly List<FishStruct> _fishStructs = new List<FishStruct>();

        private void PrefillFishList()
        {
            _fishStructs.Add(new FishStruct(1, "Tetra", 3, 3));
            _fishStructs.Add(new FishStruct(2, "Angel Fish", 2, 3));

        }

        public List<FishStruct> GetAllFishes()
        {
            PrefillFishList();
            return _fishStructs;
        }

        public void AddFish(FishStruct fishStruct)
        {
            _fishStructs.Add(fishStruct);
        }
    }
}
