using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bear : IAnimal
    {
        public String Species { get => "bear"; }
        // public String Species { get => GetType().Name; }
        public int Age { get; set; }

        private bool _isGrizzly;

        public void setAge()
        {
            Console.WriteLine("How old is the bear? ");
            Age = Convert.ToInt32(Console.ReadLine());
        }
        public void RequestUniqueCharacteristic()
        {
            Console.WriteLine("Is it a grizzly bear (yes/no)? ");
            _isGrizzly = Console.ReadLine().ToLower() == "yes"; 
        }
        public string GetDescription()
        {
            return $"{Age}-years-old {(_isGrizzly ? "" : " non-")}grizzly {Species}";
        }
    }
}
