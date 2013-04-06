using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsUtilities
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public bool ismarriage;

        public Person(string _firstName, string _lastName, int _age, bool _ismarriage)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
            ismarriage = _ismarriage;
        }
    }
}
