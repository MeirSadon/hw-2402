using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw_2402
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        protected int numberOfSeats;

        public Car()
        {
        }
        public Car(string fileName)
        {
            Car carFromFile = Car.DeserializeACar(fileName);
            this.Model = carFromFile.Model;
            this.Brand = carFromFile.Brand;
            this.Year =  carFromFile.Year;
            this.Color = carFromFile.Color;            
        }
        public Car(string model, string brand, int year, string color, int codan, int numbrOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numbrOfSeats;

        }
        public int GetCodan()
        {
            return this.codan;
        }
        public int GetNumberOfSeats()
        {
            return this.numberOfSeats;
        }
        protected void ChangeNumberOfSeats(int newNumberOfSeats)
        {
            this.numberOfSeats = newNumberOfSeats;
        }
        public static void SerializeACar(string fileName, Car car)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                    myXmlSerializer.Serialize(file, car);
            }
        }
        public static void SerializerCarArray(string fileName, Car[] cars)
        {
            XmlSerializer myArrXmlSerializer = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream($"{fileName}", FileMode.Create))
            {
                 myArrXmlSerializer.Serialize(file, cars);
            }
        }
        public static Car DeserializeACar(string fileName)
        {
            Car c = new Car();
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
               c = myXmlSerializer.Deserialize(file) as Car;
            }
            return c;
        }
        public static Car[] DeserializerCarArray(string fileName)
        {
            Car[] cars;
            XmlSerializer myArrXmlSerializer = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                cars = myArrXmlSerializer.Deserialize(file) as Car[];
            }
            return cars;
        }
        public bool CarCompare(string fileName)
        {
            Car carFromFile = Car.DeserializeACar(fileName) as Car;
            if (carFromFile.Model == this.Model && carFromFile.Brand == this.Brand && carFromFile.Year == this.Year && carFromFile.Color == this.Color)
                return true;
            return false;
        }
        public override string ToString()
        {
            return $"Car Model: {Model, 10}. Brand: {Brand, 10}. Year: {Year, 4}." +
                $" Color: {Color, 7}.Codan: {codan, 4}. Number Of Seats: {numberOfSeats, 2}.";
        }

    }
}
