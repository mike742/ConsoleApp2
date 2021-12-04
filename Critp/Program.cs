using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Critp
{
    public class Customer
    {
        [XmlElement("name")]
        public string Name { set; get; }
        [XmlElement("creditcard")]
        public string CreditCard { set; get; }
        [XmlElement("password")]
        public string Password { set; get; }
    }

    [XmlRoot("customers")]
    public class Customers
    {
        [XmlElement("customer")]
        public List<Customer> customers;
    }

    class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            for (int i = 1; i <= 20; i++)
            {
                if (i % 3 == 0) // 3 6 9 12 15 18 
                {
                    sum += i;
                }
            }

            Console.WriteLine($"sum = {sum}");

            Console.WriteLine("-----------------------------------------");

            String fileName = "CreditCard.xml";
            String key = GenerateSecretString();
            // Console.WriteLine($"SecretString = {key}");


            if (File.Exists(fileName))
            {
                var xml = File.ReadAllText(fileName);
                // Console.WriteLine(xml);

                Customers obj = serializeXml<Customers>(xml);

                foreach (var customer in obj.customers)
                {
                    Console.WriteLine($"{customer.Name} {customer.CreditCard} {customer.Password}");
                }

                
                // 
                for (int i = 0; i < obj.customers.Count; i++)
                {
                    obj.customers[i].Password = SaltAndHash(obj.customers[i].Password);
                    obj.customers[i].CreditCard = EncryptString(key, obj.customers[i].CreditCard);
                }
                deserializeXml<Customers>(obj);


                Console.WriteLine("\nSecured information:");
                foreach (var customer in obj.customers)
                {
                    Console.WriteLine($"{customer.Name} {customer.CreditCard} {customer.Password}");
                    Console.WriteLine("Decripted Credit Card Number: " +
                        DecryptString(key, customer.CreditCard));

                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }

        public static T serializeXml<T>(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }
        public static void deserializeXml<T>(T obj)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, obj);
                File.WriteAllText("result.xml", sw.ToString());
            }
        }

        // From MSDN web-site
        public static string GenerateSecretString()
        {
            Random rnd = new Random();
            string res = string.Empty;
            for (int i = 1; i <= 32; i++)
            {
                res += (char)rnd.Next(48, 122);
            }

            return res;
        }
        public static string SaltAndHash(string str)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: str,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            // Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}
