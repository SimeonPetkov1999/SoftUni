using _04.WildFarm.Models.FoodModels.Interfaces;

namespace _04.WildFarm.Models.Animals.Interfaces
{
    interface IAnimal 
    {
        public string Name { get;}
        public double Weight { get;}
        public int FoodEaten { get;}
        public string ProduceSound();
        public void Eat(IFood food);
    }
}
