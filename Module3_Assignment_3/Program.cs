using Module3_Assignment_3.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module3_Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Microsoft.EntityFrameworkCore
            // Microsoft.EntityFrameworkCore.Tools
            // Pomelo.EntityFrameworkCore.MySql

            // scaffold-dbcontext "server=localhost;user=root;password=1234;database=northwind" Pomelo.EntityFrameworkCore.mysql -outputdir DbModels

            northwindContext context = new northwindContext();

            List<string> cities = context
                .Customers
                .Select(c => c.City)
                .Distinct()
                .ToList();

            foreach (string ct in cities)
            {
                Console.WriteLine(ct);
            }


            string city = "Minneapolis"; // select * ...... where city = "New York"
            List<Customer> customers = context
                .Customers
                .Where(c => c.City == city)
                .ToList();

            Console.WriteLine($"There are {customers.Count} customers in {city}:");
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.City + " " + c.FirstName + " " + c.LastName);
            }
        }
    }
}
