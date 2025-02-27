﻿using System;
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

        public FishCollection()
        {
            
        }

        public FishCollection(IFishCollectionRepository fishRepository)
        {
            _fishRepository = fishRepository;
        }

        public void AddFish(FishModel fishModel)
        {
            var fish = new Fish(fishModel);

            _fishRepository.AddFish(Convert(fish));
        }

        private FishStruct Convert(IFish fish)
        {
            return new FishStruct(fish.FishId, fish.FishName, fish.FishType, fish.FishSize);
        }

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

        public void DeleteFish(int fishId)
        {
            _fishRepository.DeleteFish(fishId);
        }
    }
}
