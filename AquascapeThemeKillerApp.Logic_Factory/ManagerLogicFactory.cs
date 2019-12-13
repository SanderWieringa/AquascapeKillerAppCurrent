using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic_Factory
{
    public static class ManagerLogicFactory
    {
        public static IManager CreateManager()
        {
            return new Manager();
        }
    }
}
