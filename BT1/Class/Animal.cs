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
            sound = "Boo, boo, boo";
            milk = 0;
        }

        public override int GiveBirth()
        {
            return base.GiveBirth();
        }
    }
}