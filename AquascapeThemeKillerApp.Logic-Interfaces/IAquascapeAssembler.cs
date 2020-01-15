using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IAquascapeAssembler
    {
        AquascapeModel AssemblePlants(List<IPlant> selectedPlants, AquascapeModel sessionAquascapeModel);
        AquascapeModel AssembleFishes(List<IFish> selectedFishes, AquascapeModel sessionAquascapeModel);
        AquascapeModel CreateAquascape();
        string AssembleAquascape(List<object> list);
    }
}
