using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XML_serialization
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    public class Shape {
        public virtual string Colour { get; set; }
        public virtual double Area { get; }
    }

    public class Rectangle : Shape
    {
        public override string Colour { get; set; }
        public override double Area => Width * Height;
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Circle : Shape
    {
        public override string Colour { get; set; }
        public override double Area => Math.PI * Math.Pow(Radius, 2);
        public double Radius { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
            };

            string fileXml = deserializeXml(listOfShapes);

            // Console.WriteLine(fileXml);
            Console.WriteLine("Loading shapes from XML:");

            List<Shape> loadedShapesXml = serializeXml<List<Shape>>(fileXml);
            foreach (Shape item in loadedShapesXml)
            {
                Console.WriteLine($"{item.GetType().Name} is {item.Colour} and has anarea of { item.Area} ");
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

        public static string deserializeXml<T>(T obj)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, obj);
                // File.WriteAllText("shapes.xml", sw.ToString());
                return sw.ToString();
            }
        }
    }
}
