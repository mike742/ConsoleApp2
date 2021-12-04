using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            //IAnimal bear = new Bear();
            //IAnimal lion = new Lion();
            //IAnimal wolf = new Wolf();
            //animals.Add(bear);
            //animals.Add(lion);
            //animals.Add(wolf);

            int cageNumber = 3;
            
            while (animals.Count < cageNumber)
            {
                Console.WriteLine("What is the animal’s species? ");
                string answer = Console.ReadLine();

                IAnimal animalToAdd;

                switch (answer.ToLower())
                {
                    case "lion":
                        animalToAdd = new Lion();
                        break;
                    case "wolf":
                        animalToAdd = new Wolf();
                        break;
                    case "bear":
                        animalToAdd = new Bear();
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        animalToAdd = null;
                        break;
                }

                if (animalToAdd != null)
                {
                    animalToAdd.setAge();
                    animalToAdd.RequestUniqueCharacteristic();
                    animals.Add(animalToAdd);
                }
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal.GetDescription());
            }
        }
    }
}
