using AquascapeThemeKillerApp.DAL_Factory;
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

        private const string PlantError = "This plant could not be added!: {0}";
        private const string FishError = "This fish could not be added!: {0}";

        Aquascape aquascape = new Aquascape();
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private AquascapeGenerator _aquascapeGenerator;

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
            List<IPlant> plantList = new List<IPlant>();

            try
            {
                foreach (var plant in plantStructList)
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
            List<IFish> fishList = new List<IFish>();

            try
            {
                foreach (var fish in fishStructList)
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
            List<IAquascape> aquascapeList = new List<IAquascape>();

            try
            {
                foreach (var aquascape in _userRepository.GetAllAquascapes())
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

        public AquascapeModel AssemblePlants(List<IPlant> selectedPlants)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (var plant in selectedPlants)
            {
                if (!_aquascapeGenerator.TryAddPlant(plant as Plant, aquascape))
                {
                    throw new ArgumentException(string.Format(PlantError, plant));
                }
            }

            return new AquascapeModel(aquascape);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedFishes"></param>
        /// <returns></returns>
        public AquascapeModel AssembleFishes(List<IFish> selectedFishes)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (var fish in selectedFishes)
            {
                if (!_aquascapeGenerator.TryAddFish(fish as Fish, aquascape))
                {
                    throw new ArgumentException(string.Format(FishError, fish));
                    
                }
            }

            return new AquascapeModel(aquascape);
        }

        public string AssembleAquascape(List<object> list)
        {
            throw new NotImplementedException();
          
        }
    }
}
