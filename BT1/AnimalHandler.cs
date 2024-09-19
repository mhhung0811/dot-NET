using BT1.Class;
using BT1.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class AnimalHandler
    {
        AnimalDAL animalDAL;

        public AnimalHandler()
        {
            animalDAL = new AnimalDAL();
        }

        public void AddAnimal(Animal animal)
        {
            animalDAL.AddAnimal(animal);
        }

        public List<GridDO> getGridData()
        {
            List<GridDO> res = new List<GridDO>();
            List<Animal> animals = animalDAL.GetAnimals();

            GridDO cows = new GridDO();
            GridDO sheeps = new GridDO();
            GridDO goats = new GridDO();

            cows.Type = "COW";
            sheeps.Type = "SHEEP";
            goats.Type = "GOAT";

            foreach (Animal animal in animals)
            {
                switch (animal.type)
                {
                    case "COW":
                        cows.CurrentAmount ++;
                        cows.TotalMilk += animal.milk;
                        break;
                    case "SHEEP":
                        sheeps.CurrentAmount ++;
                        sheeps.TotalMilk += animal.milk;
                        break;
                    case "GOAT":
                        goats.CurrentAmount ++;
                        goats.TotalMilk += animal.milk;
                        break;
                    default:
                        break;
                }
            }

            res.Add(cows);
            res.Add(sheeps);
            res.Add(goats);
            return res;
        }

        public void Milking()
        {
            List<Animal> animals = animalDAL.GetAnimals();

            foreach (Animal animal in animals)
            {
                animal.Milking();
                animalDAL.UpdateAnimal(animal);
            }
        }

        public List<int> Born()
        {
            List<Animal> animals = animalDAL.GetAnimals();
            List<int> res = new List<int>();
            res.Add(0);
            res.Add(0);
            res.Add(0);

            foreach (Animal animal in animals)
            {
                switch (animal.type)
                {
                    case "COW":
                        res[0] += animal.GiveBirth();
                        break;
                    case "SHEEP":
                        res[1] += animal.GiveBirth();
                        break;
                    case "GOAT":
                        res[2] += animal.GiveBirth();
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < res[0]; i++)
            {
                Console.WriteLine("work");
                animalDAL.AddAnimal(new Cow());
            }
            for (int i = 0; i < res[1]; i++)
            {
                animalDAL.AddAnimal(new Sheep());
            }
            for (int i = 0; i < res[0]; i++)
            {
                animalDAL.AddAnimal(new Goat());
            }
            return res;
        }
    }
}
