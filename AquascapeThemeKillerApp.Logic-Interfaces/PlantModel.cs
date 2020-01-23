namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public class PlantModel : IPlant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Difficulty { get; set; }

        public PlantModel(IPlant plant) : this(plant.PlantId, plant.PlantName, plant.Difficulty)
        {

        }

        public PlantModel(int plantId, string plantName, int difficulty)
        {
            PlantId = plantId;
            PlantName = plantName;
            Difficulty = difficulty;
        }

        public PlantModel()
        {
            
        }
    }
}
