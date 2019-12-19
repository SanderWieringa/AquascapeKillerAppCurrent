using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.Tests
{
    public class FishMemoryContext : IFishContext
    {
        private readonly List<FishStruct> _fishStructs = new List<FishStruct>();

        public List<FishStruct> GetAllFishes()
        {
            return _fishStructs;
        }

        public void AddFish(FishStruct fishStruct)
        {
            _fishStructs.Add(fishStruct);
        }

        public void DeleteFish(int fishId)
        {
            foreach (var fish in _fishStructs.Where(fish => fish.FishId == fishId).ToArray()) _fishStructs.Remove(fish);
        }
    }
}
