using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic
{
    public class FishCollection : IFishCollection
    {
        private readonly IFishCollectionRepository _fishRepository = FishDalFactory.CreateFishCollectionRepository();

        public List<IFish> GetAllFishes()
        {
            List<IFish> fishList = new List<IFish>();

            try
            {
                foreach (var fish in _fishRepository.GetAllFishes())
                {
                    fishList.Add(new Fish(fish));
                }

                return fishList;
            }
            catch (Exception e)
            {
                return new List<IFish>();
            }
            
        }
    }
}
