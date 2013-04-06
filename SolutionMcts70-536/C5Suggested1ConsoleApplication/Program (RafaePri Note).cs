using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using SolutionsUtilities;
using System.Globalization;



namespace C5Suggested1ConsoleApplication
{
    class Program
    {
        //Serializações em XML precisam de um construtor sem parametro
        //Serializações em XML não executam o método OnDeserializationCallback 

        static void Main(string[] args)
        {
            //Car car = new Car("X5", "BMW", 2002, "White", "XYZ-1234");
            Airplane airplane = new Airplane("F22", "Air", 2002, "White", "BR-RJ / PT-LB");

            SerializeBin(airplane);

            SerializeSoap(airplane);

            //SerializeXML(car, typeof(Car));
            SerializeXML(airplane, typeof(Airplane));

            //Car bmw = (Car)DeserializeXML(typeof(Car));
            //Car bmw = (Car)DeserializeBin();

            Airplane air = (Airplane)DeserializeXML(typeof(Airplane));
            //Airplane air = (Airplane)DeserializeBin();

            //Excessão! impossivel cast de classe base para classe filha
            //Car a = (Car)new Vehicle();
            //Vehicle c = (Vehicle)a;

            //Excessão! impossivel cast de classe base para classe filha
            //Vehicle b = new Vehicle();
            //Car d = (Car)b;

            //Válido! cast somente de classe filha para pai
            //Vehicle e = new Car();
            //Car f = (Car)e;

            //Válido! cast somente de classe filha para pai
            //Car g = new Car();
            //Vehicle h = (Vehicle)g;

            Console.WriteLine("Car model {0}, manufacturer {1}, color {2}, at speed {3}", air.Model, air.Manufacturer, air.Color, air.Speed);

            Console.ReadKey();
        }

        static void SerializeXML(object graph, Type typeobject)
        {
            XmlSerializer xs = new XmlSerializer(typeobject);

            using(FileStream fs = new FileStream("CarXml.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, graph);
            }

            Console.WriteLine("Car xml serialized");
        }

        static object DeserializeXML(Type typeobject)
        {
            XmlSerializer xs = new XmlSerializer(typeobject);

            using(FileStream fs = new FileStream("CarXml.xml", FileMode.OpenOrCreate))
            {
                return xs.Deserialize(fs);
            }
        }

        static void SerializeBin(object graph)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using(FileStream fs = new FileStream("Carbin.Dat", FileMode.Create))
            {
                bf.Serialize(fs, graph);
            }

            Console.WriteLine("Car bin serialized");
        }

        static void SerializeSoap(object graph)
        {
            SoapFormatter sf = new SoapFormatter();

            using(FileStream fs = new FileStream("Carsoap.sop", FileMode.OpenOrCreate))
            {
                sf.Serialize(fs, graph);
            }

            Console.WriteLine("Car soap serialized");
        }

        static object DeserializeBin()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using(FileStream fs = new FileStream("Carbin.Dat", FileMode.OpenOrCreate))
            {
                return bf.Deserialize(fs);
            }
        }

        static object DeserializeSoap()
        {
            SoapFormatter sf = new SoapFormatter();

            return sf.Deserialize(File.Open("Carsoap.sop", FileMode.Open, FileAccess.Read));
        }
    }
}
