﻿using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class User : IAquascapeCollection
    {
        private readonly IAquascapeCollectionRepository _userRepository = AquascapeDALFactory.CreateUserRepository();

        private IAquascapeRepository _aquascapeRepository = AquascapeDALFactory.CreateAquascapeRepository();

        

        
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        

        public User(int userId, string userName, string password)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
        }

        public User(IAquascapeCollectionRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User()
        {

        }

        private AquascapeModel ConvertToAquascapeModel(AquascapeStruct aquascapeStruct)
        {
            var aquascapeModel = new AquascapeModel
            {
                FishInAquarium = ConvertFishStructList(aquascapeStruct.FishInAquarium),
                PlantsInAquarium = ConvertPlantStructList(aquascapeStruct.PlantsInAquarium),
                AquascapeId = aquascapeStruct.AquascapeId,
                Name = aquascapeStruct.Name,
                Difficulty = aquascapeStruct.AquascapeId
            };

            return aquascapeModel;
        }

        private static List<IPlant> ConvertPlantStructList(List<PlantStruct> plantStructList)
        {
            var plantList = new List<IPlant>();

            try
            {
                foreach (PlantStruct plant in plantStructList)
                {
                    plantList.Add(new Plant(plant));
                }

                return plantList;
            }
            catch (Exception e)
            {
                return new List<IPlant>();
            }
                
        }

        private List<IFish> ConvertFishStructList(List<FishStruct> fishStructList)
        {
            var fishList = new List<IFish>();

            try
            {
                foreach (FishStruct fish in fishStructList)
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

        public void RemoveAquascape(int aquascapeId)
        {
            _userRepository.RemoveAquascape(aquascapeId);
        }

        public void AddAquascape(AquascapeModel aquascapeModel)
        {
            var aquaScape = new Aquascape(aquascapeModel);

            _userRepository.AddAquascape(aquaScape.Convert(aquaScape));
        }

        public List<IAquascape> GetAllAquascapes()
        {
            var aquascapeList = new List<IAquascape>();

            try
            {
                foreach (AquascapeStruct aquascape in _userRepository.GetAllAquascapes())
                {
                    aquascapeList.Add(new Aquascape(aquascape));
                }

                return aquascapeList;
            }
            catch (Exception e)
            {
                
                return new List<IAquascape>();
            }
            
        }

        public AquascapeModel GetAquascapeById(int aquascapeId)
        {
            return ConvertToAquascapeModel(_userRepository.GetAquascapeById(aquascapeId));
        }

        // ToDo: Implement styles
        
        public AquascapeModel GetAquascapeByStyle()
        {
            throw new NotImplementedException();
        }

        
    }
}
