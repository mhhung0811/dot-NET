using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1.Class
{
    internal class Animal
    {
        public string id;
        public string type;
        public string sound;
        public float milk;

        public Animal() 
        {
            id = type = sound = string.Empty;
            milk = 0;
        }

        public virtual void Sound()
        {
            Console.WriteLine(sound);
        }

        public virtual void MakeSound() { Console.WriteLine(sound); }

        public virtual int GiveBirth() { return 0; }

        public virtual float Milking() { return 0; }
    }

    internal class Cow : Animal
    {
        public Cow() 
        {            
            id = "COW" + Guid.NewGuid().GetHashCode().ToString();
            type = "COW";
            sound = "Moo, moo, moo";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 2);
        }

        public override float Milking()
        {
            Random random = new Random();
            Console.WriteLine("Cow milk");
            milk = random.Next(0, 20);
            return milk;
        }
    }

    internal class Sheep : Animal
    {
        public Sheep()
        {
            id = "SHEEP" + Guid.NewGuid().GetHashCode().ToString();
            type = "SHEEP";
            sound = "Sheep, sheep, sheep";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 4);
        }

        public override float Milking()
        {
            Random random = new Random();
            milk = random.Next(0, 5);
            return milk;
        }
    }

    internal class Goat : Animal
    {
        public Goat()
        {
            id = "GOAT" + Guid.NewGuid().GetHashCode().ToString();
            type = "GOAT";
            sound = "GOAT, GOAT, GOAT";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 6);
        }

        public override float Milking()
        {
            Random random = new Random();
            milk = random.Next(0, 10);
            return milk;
        }
    }
}