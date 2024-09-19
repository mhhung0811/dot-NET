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
    }
}
