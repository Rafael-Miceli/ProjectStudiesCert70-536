using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C1L1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //é possivel fazer CAST do tipo base para o tipo que herda da base, mas não o oposto
                Manager p = new Manager("Tony", "Allen", 32, Person.Genders.Female, "777-7777", "teste");
                Console.WriteLine(p);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }            
        }
    }

    class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public Genders gender;

        public enum Genders
        {
            None,
            Male,
            Female
        }

        //public Person()
        //{
        //}

        public Person(string _Firstname, string _Lastname, int _Age, Genders _gender)
        {
            FirstName = _Firstname;
            LastName = _Lastname;
            Age = _Age;
            gender = _gender;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " (" + gender + "), age " + Age;
        }
    }


    class Manager: Person 
    {
        public string phoneNumber;
        public string officeLocation;

        public Manager(string _Firstname, string _Lastname, int _Age, Genders _gender, string _phoneNumber, string _officeLocation)
            : base(_Firstname, _Lastname, _Age, _gender)
        {
            phoneNumber = _phoneNumber;
            officeLocation = _officeLocation;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + phoneNumber + ", " + officeLocation;
        }
    }
}
