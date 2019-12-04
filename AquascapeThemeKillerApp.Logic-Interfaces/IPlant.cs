using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IPlant
    {
        int PlantId { get; set; }
        string PlantName { get; set; }
        int Difficulty { get; set; }

    }
}
