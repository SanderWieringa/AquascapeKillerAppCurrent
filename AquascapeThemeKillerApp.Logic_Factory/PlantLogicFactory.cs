﻿using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic_Factory
{
    public static class PlantLogicFactory
    {
        public static IPlantCollection CreatePlantCollection()
        {
            return new PlantCollection();
        }
    }
}
