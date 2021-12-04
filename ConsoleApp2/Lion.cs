using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Lion : IAnimal
    {
        public String Species { get => "lion"; }

        public int Age { get; set; }

        private String _maneColor;

        public string GetDescription()
        {
            return $"{Age}-years-old {Species} with a {_maneColor} mane";
        }

        public void RequestUniqueCharacteristic()
        {
            Console.WriteLine("What colour is its mane? ");
            _maneColor = Console.ReadLine();
        }

        public void setAge()
        {
            Console.WriteLine("How old is the lion? ");
            Age = Convert.ToInt32(Console.ReadLine());
        }
    }
}
