using System;
using System.Numerics;

namespace BigIntegerDemo
{
    class Program
    {
        public static string[] larges = new[] {
            "",
            "thousand",
            "Million",
            "Billion",
            "Trillion",
            "Quadrillion",
            "Quintillion",
            "Sextillion",
            "Septillion",
            "Octillion",
            "Nonillion",
            "Decillion",
            "Undecillion",
            "Duodecillion",
            "Tredecillion",
            "Quattuordecillion",
            "Quindecillion",
            "Sexdecillion",
            "Septendecillion",
            "Octodecillion",
            "Novemdecillion",
            "Vigintillion",
            "Centillion"
        };

        static string partToWords(string part)
        {
            part = part.PadLeft(3, '0');
            
            string[] units = new[] { 
                "", "one", "two", "three", "four", "five",
                "six", "seven", "eight", "nine", "ten", "eleven",
                "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
                "seventeen", "eighteen", "nineteen"
            };

            string[] tensUnits = new[] { 
                "", "", "twenty", "thirty", "fourty", "fifty",
                "sixty", "seventy", "eighty", "ninty"
            };

            string words = "";

            if (part[0] != '0')
            {
                int ind = Convert.ToInt32(part[0].ToString());
                words += units[ind];

                if (part[0] == '1')
                {
                    words += " hundred ";
                }
                else
                {
                    words += " hundreds ";
                }
            }

            // x1x  x3
            if (part[1] == '1')
            {
                int ind = Convert.ToInt32("1" + part[2].ToString());
                words += units[ind];
            }
            else if (part[1] != '0')
            {
                int ind = Convert.ToInt32(part[1].ToString());
                words += " " + tensUnits[ind];
            }

            if (part[2] != '0' && part[1] != '1')
            {
                int ind = Convert.ToInt32(part[2].ToString());
                words += " " + units[ind];
            }

            return words;
        }

        static void Main(string[] args)
        {
            BigInteger bi = BigInteger.Parse("189515000000000000000000000000000");
            string strNumber = bi.ToString("N0");

            string[] parts = strNumber.Split(",");

            string res = "";

            for(int i = 0; i < parts.Length; ++i)
            {
                string temp = partToWords(parts[i]);

                if (temp != "")
                {
                    int ind = parts.Length - 1 - i;
                    res += temp + " " + larges[ind] + " ";
                }
                
            }

            Console.WriteLine(res);
            
            
            
            
            
            /*
            BigInteger bi1 = new BigInteger(Int64.MaxValue);
            BigInteger bi2 = new BigInteger(Int64.MaxValue);

            BigInteger sum = BigInteger.Add(bi1, bi2);
            sum = bi2 + bi1;

            Console.WriteLine($"sum = {sum}");
            */
        }
    }
}
