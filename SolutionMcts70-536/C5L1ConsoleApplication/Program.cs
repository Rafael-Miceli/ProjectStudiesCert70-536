using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace C5L1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
             if (args.Length == 0)
            {
                // If they provide no arguments, display the last person
                Person p = Deserialize();
                Console.WriteLine(p.ToString());
            }
            else
            {
                try
                {
                    if (args.Length != 4)
                    {
                        throw new ArgumentException("You must provide four arguments.");
                    }

                    DateTime dob = new DateTime(Int32.Parse(args[1]), Int32.Parse(args[2]), Int32.Parse(args[3]));
                    Person p = new Person(args[0], dob);
                    Console.WriteLine(p.ToString());

                    Serialize(p);
                }
                catch (Exception ex)
                {
                    DisplayUsageInformation(ex.Message);
                }
            }

            Console.ReadKey();
        }

        private static void DisplayUsageInformation(string message)
        {
            Console.WriteLine("\nERROR: Invalid parameters. " + message);
            Console.WriteLine("\nSerialize_People \"Name\" Year Month Date");
            Console.WriteLine("\nFor example:\nSerialize_People \"Tony\" 1922 11 22");
            Console.WriteLine("\nOr, run the command with no arguments to display that previous person.");
        }

        private static void Serialize(Person sp)
        {
            // TODO: Serialize sp object         to binnaryserializer .dat to xml .xml
            using (FileStream fs = new FileStream("Person.xml", FileMode.Create))
            {
                //Exercise Number 1
                BinaryFormatter bf = new BinaryFormatter();

                //XmlSerializer xs = new XmlSerializer(typeof(Person));

                Console.WriteLine("Serialazed");

                bf.Serialize(fs, sp);
                //xs.Serialize(fs, sp);
            }
        }

        private static Person Deserialize()
        {
            Person dsp = null;

            // TODO: Restore previously serialized Person object
            //Exercise Number 1
            BinaryFormatter bf = new BinaryFormatter();
            //XmlSerializer xs = new XmlSerializer(typeof(Person));

            dsp = (Person)bf.Deserialize(File.Open("Person.xml", FileMode.OpenOrCreate));

            return dsp;
        }
        
    }



    [Serializable]        //Iserializable so funciona para serializar binaryformater  
    public class Person : ISerializable//IDeserializationCallback
    {
        public string name;
        public DateTime dateOfBirth;
        [NonSerialized]
        public int age;
        
        public Person(string _name, DateTime _dateOfBirth)
        {
            name = _name;
            dateOfBirth = _dateOfBirth;
            //CalculateAge();
            //Console.WriteLine("testando");
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            dateOfBirth = info.GetDateTime("Date of birth");
            CalculateAge();
            //Console.WriteLine("testando");
        }

        //public Person()
        //{
        //}

        public override string ToString()
        {
            return name + " was born on " + dateOfBirth.ToShortDateString() + " and is " + age.ToString() + " years old.";
        }

        private void CalculateAge()
        {
            age = DateTime.Now.Year - dateOfBirth.Year;

            // If they haven't had their birthday this year, 
            // subtract a year from their age
            if (dateOfBirth.AddYears(DateTime.Now.Year - dateOfBirth.Year) > DateTime.Now)
            {
                age--;
            }
        }

        //Exercise 1 and 2
        //public void OnDeserialization(object sender)
        //{
        //    //After deserialization, calculate the age
        //    CalculateAge();
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //throw new NotImplementedException();

            info.AddValue("Name", name);
            info.AddValue("Date of birth", dateOfBirth);
        }
    }
}
