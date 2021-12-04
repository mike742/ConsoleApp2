using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IAnimal
    {
        public String Species { get; }
        public int Age { get; set; }
        public void setAge();
        public void RequestUniqueCharacteristic();
        public String GetDescription();
    }
}
