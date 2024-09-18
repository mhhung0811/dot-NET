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

        public virtual int GiveBirth() { return 0; }

        public virtual int Milking() { return 0; }
    }

    internal class Cow : Animal
    {
        public Cow() 
        {
            Random random = new Random();
            id = random.Next(0, 65536);
            type = "COW";
            sound = "Moo, moo, moo";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 2);
        }

        public override int Milking()
        {
            Random random = new Random();
            return random.Next(0, 20);
        }
    }

    internal class Sheep : Animal
    {
        public Sheep()
        {
            Random random = new Random();
            id = random.Next(0, 65536);
            type = "SHEEP";
            sound = "Sheep, sheep, sheep";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 4);
        }

        public override int Milking()
        {
            Random random = new Random();
            return random.Next(0, 5);
        }
    }

    internal class Goat : Animal
    {
        public Goat()
        {
            Random random = new Random();
            id = random.Next(0, 65536);
            type = "GOAT";
            sound = "GOAT, GOAT, GOAT";
            milk = 0;
        }

        public override int GiveBirth()
        {
            Random random = new Random();
            return random.Next(0, 6);
        }

        public override int Milking()
        {
            Random random = new Random();
            return random.Next(0, 10);
        }
    }
}