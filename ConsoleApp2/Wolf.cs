using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Wolf : IAnimal
    {
        public String Species { get => "wolf"; }

        public int Age { get; set; }

        private int _speed;

        public string GetDescription()
        {
            return $"{Age}-years-old {Species} that runs {_speed}km/h.";
        }

        public void RequestUniqueCharacteristic()
        {
            Console.WriteLine("How fast can it run (in km/h)? ");
            _speed = Convert.ToInt32(Console.ReadLine());
        }

        public void setAge()
        {
            Console.WriteLine("How old is the wolf? ");
            Age = Convert.ToInt32(Console.ReadLine());
        }
    }
}
