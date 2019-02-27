using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw_2402
{
    class Program
    {
        public static string path = @"c:/temp/"; 
        static void Main(string[] args)
        {
            
            Car c = new Car("Mazda", "x5", 2014, "Black", 4323, 4);
            Console.WriteLine(c);
            Car[] cars =
            {
                new Car("Mazda", "x5", 2014, "Black", 4323, 4),
                new Car("Mitzubishi", "Family", 2019, "white", 9876, 6),
                new Car("Shevrolet", "Cavelir", 1998, "Green", 3423, 5),
            };

            XmlSerializer myArrXmlSerializer = new XmlSerializer(typeof(Car[]));
            
            using (Stream file = new FileStream(path + "CarArray.Xml", FileMode.Create))
            {
                myArrXmlSerializer.Serialize(file, cars);
            }
            using (Stream file = new FileStream(path + "CarArray.Xml", FileMode.Open))
            {
                cars = myArrXmlSerializer.Deserialize(file) as Car[];
            }
            foreach(Car car in cars)
            {
                Console.WriteLine(car);
            }
            



            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            
            
            using (Stream file = new FileStream(path + "Car.Xml", FileMode.Create))
            {
                myXmlSerializer.Serialize(file, c);
            }
            using (Stream file = new FileStream(path + "Car.Xml", FileMode.Open))
            {
                c = myXmlSerializer.Deserialize(file) as Car;
            }
            Console.WriteLine(c);

            Car.SerializeACar(path + "Car.Xml", c);
            Car.SerializerCarArray(path + "carArray.Xml", cars);
            Car.DeserializeACar(path + "Car.Xml");
            Car.DeserializerCarArray(path + "carArray.Xml");
        }
    }
}
