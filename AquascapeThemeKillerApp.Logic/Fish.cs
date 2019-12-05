using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class Fish : IFish
    {
        public int FishId { get; set; }
        public string FishName { get; set; }
        public int FishType { get; set; }
        public int FishSize { get; set; }
        
        public Fish(int fishId, string fishName, int fishType, int fishSize)
        {
            FishId = fishId;
            FishName = fishName;
            FishType = fishType;
            FishSize = fishSize;
        }

        public Fish(FishModel fishModel) : this(fishModel.FishId, fishModel.FishName, fishModel.FishType, fishModel.FishSize)
        {

        }

        public Fish(FishStruct fishStruct) : this(fishStruct.FishId, fishStruct.FishName, fishStruct.FishType, fishStruct.FishSize)
        {

        }

    }
}
