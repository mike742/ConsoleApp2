using System;
using System.Text.RegularExpressions;

namespace RegExp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Regex.IsMatch("aaaaa", @"^a{5}$"));
            //PrintIsMatch("aaaaaa", @"^a{5}$");
            //PrintIsMatch("nnn", @"^n{3}$");
            //PrintIsMatch("Hel9", @"^[A-Za-z0-9]{4}$");
            //PrintIsMatch("aaaaaaa", @"^[a-z]{4,6}$");
            //PrintIsMatch("A", @"^[Aa]$");
            //PrintIsMatch("1234", @"^[0-9]{4}$");
            //PrintIsMatch("00000", @"^\d{4}$");
            //PrintIsMatch("lucysmith1234", @"^\w{4,}$");
            //PrintIsMatch("cat", @"^c?at$");
            //PrintIsMatch("ccccccccccccccccccccat", @"^c*at$");
            //PrintIsMatch("cat", @"^c+t$");

            //PrintIsMatch("sut", @"^s(a|i)t$"); // sit sat


            Console.WriteLine("The default regular expression checks for at least one digit.");

            // string input = Console.ReadLine();
            bool isExit = false; 
            ConsoleKeyInfo cki;
            do
            {
                // two inputs, two realine
                // PrintIsMatch(userInputStr, userInputRegEx);

                Console.WriteLine("Press ESC to end or any key to try again.");
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                {
                    isExit = true;
                }
                else
                {
                    isExit = false;
                }
            }
            while (!isExit);
            Console.WriteLine("Have a nice day!");

        }
        static void PrintIsMatch(string value, string re)
        {
            Regex rx = new Regex( re );
            Console.WriteLine( $"{value} and {rx} is {rx.IsMatch(value)}" );
        }
    }
}
