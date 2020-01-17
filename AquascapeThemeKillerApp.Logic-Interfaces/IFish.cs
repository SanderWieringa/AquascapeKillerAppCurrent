using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.Logic;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IFish
    {
        int FishId { get; set; }
        string FishName { get; set; }
        FishType FishType { get; set; }
        int FishSize { get; set; }
    }
}
