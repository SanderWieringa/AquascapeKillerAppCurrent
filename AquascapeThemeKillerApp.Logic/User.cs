using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
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
            this._userRepository = userRepository;
        }

        public User()
        {

        }

        private AquascapeModel ConvertToAquascapeModel(AquascapeStruct aquascapeStruct)
        {
            var aquascapeModel = new AquascapeModel();
            aquascapeModel.FishInAquarium = ConvertFishStructList(aquascapeStruct.FishInAquarium);
            aquascapeModel.PlantsInAquarium = ConvertPlantStructList(aquascapeStruct.PlantsInAquarium);
            aquascapeModel.AquascapeId = aquascapeStruct.AquascapeId;
            aquascapeModel.Name = aquascapeStruct.Name;
            aquascapeModel.Difficulty = aquascapeStruct.AquascapeId;

            return aquascapeModel;
        }

        private static List<IPlant> ConvertPlantStructList(List<PlantStruct> plantStructList)
        {
            List<IPlant> plantList = new List<IPlant>();

            foreach (var plant in plantStructList)
            {
                plantList.Add(new Plant(plant));
            }

            return plantList;
        }

        private List<IFish> ConvertFishStructList(List<FishStruct> fishStructList)
        {
            List<IFish> fishList = new List<IFish>();

            foreach (var fish in fishStructList)
            {
                fishList.Add(new Fish(fish));
            }

            return fishList;
        }

        public void RemoveAquascape(int aquascapeId)
        {
            _userRepository.RemoveAquascape(aquascapeId);
        }

        public void AddAquascape(AquascapeModel aquascapeModel)
        {
            var aquaScape = new Aquascape(aquascapeModel);

            _userRepository.AddAquascape((aquaScape).Convert(aquaScape));
        }

        public List<IAquascape> GetAllAquascapes()
        {
            List<IAquascape> aquascapeList = new List<IAquascape>();

            foreach (var aquascape in _userRepository.GetAllAquascapes())
            {
                aquascapeList.Add(new Aquascape(aquascape));
            }
            return aquascapeList;
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
