using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Factory
{
    public static class AquascapeLogicFactory
    {
        public static IAquascapeCollection CreateAquascapeCollection()
        {
            return new User();
        }

        public static IAquascape CreateAquascape()
        {
            return new Aquascape();
        }
    }
}
