using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionsUtilities;
using System.Collections;
using System.Collections.Specialized;

namespace C4Suggested1onsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Exercise 1

                /*

                //HashTable
                Console.WriteLine("HashTable Example");
                Console.WriteLine();

                Hashtable hsTable = new Hashtable();

                hsTable.Add(1, "One");
                hsTable.Add(2, "Two");
                if(!hsTable.ContainsValue("Three"))
                    hsTable.Add(3, "Three");

                hsTable.Remove(2);
                hsTable.Add(4, "Four");

                Console.WriteLine(hsTable[2]);

                foreach(DictionaryEntry item in hsTable)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }



                //SortedList
                Console.WriteLine();
                Console.WriteLine("SortedList Example");
                Console.WriteLine();

                SortedList sortList = new SortedList();

                sortList.Add("Rafael", 22);
                sortList.Add("Priscilla", 21);
                sortList.Add("Rosana", 37);
                sortList.Add("Marcia", 46);

                if(sortList.ContainsValue(22))
                {
                    Console.WriteLine("Deleted {0}", sortList["Rafael"]);
                    sortList.RemoveAt(sortList.IndexOfValue(22));
                }
                    

                foreach (DictionaryEntry item in sortList)
                {
                    Console.WriteLine(item.Key);
                }



                //OrderedDictionary
                Console.WriteLine();
                Console.WriteLine("OrderedDictionary Example");
                Console.WriteLine();

                OrderedDictionary orderDictionary = new OrderedDictionary();

                orderDictionary.Add(1, "One");
                orderDictionary.Add(2, "Two");
                orderDictionary.Add(3, "Three");
                orderDictionary.Add(4, "Four");
                orderDictionary.Insert(2, 5, "Five");

                foreach(DictionaryEntry item in orderDictionary)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }


                //ListDictionary
                Console.WriteLine();
                Console.WriteLine("ListDictionary Example");
                Console.WriteLine();

                ListDictionary lstDictionary = new ListDictionary();



                //Dictionary
                Console.WriteLine();
                Console.WriteLine("Dictionary Example");
                Console.WriteLine();

                Dictionary<int, string> diction = new Dictionary<int, string>();



                //NameValueCollection
                Console.WriteLine();
                Console.WriteLine("NameValueCollection Example");
                Console.WriteLine();

                NameValueCollection namevalCollection = new NameValueCollection();



                //HybridDictionary
                Console.WriteLine();
                Console.WriteLine("HybridDictionary Example");
                Console.WriteLine();

                HybridDictionary hybridDictionary = new HybridDictionary();



                //StringCollection
                Console.WriteLine();
                Console.WriteLine("StringCollection Example");
                Console.WriteLine();
                
                StringCollection strCollection = new StringCollection();



                //StringDictionary
                Console.WriteLine();
                Console.WriteLine("StringDictionary Example");
                Console.WriteLine();

                StringDictionary strDictionary = new StringDictionary();                
                */


                //Exercise 2
                TestDictHierarq teste = new TestDictHierarq();

                teste.Add("Um", new Person("Rafael", "Miceli", 22, true));
                teste.Add("Dois", new Person("Priscilla", "Valim", 21, true));
                teste.Add("Tres", new Person("Romulo", "Ramos", 21, false));
                teste.Add("Quatro", new Person("Lorena", "Miceli", 16, false));

                teste.ExibirConteudo(teste);

                Console.ReadKey();

            }
            catch(Exception)
            {
                Console.ReadKey();
                throw;
            }


            //Console.ReadKey();
        }
    }

    public class TestDictHierarq: Dictionary<string, Person>
    {
        public void method()
        {
            Console.WriteLine("Testing method");
        }

        public void ExibirConteudo(TestDictHierarq iterate)
        {
            foreach (KeyValuePair<string, Person> item in iterate)
            {
                Console.WriteLine(item.Key + " " + item.Value.firstName + " " + item.Value.lastName + " Age: " + item.Value.age + " IsMarriage? " + item.Value.ismarriage.ToString());
            }
        }
    }

    //class Person
    //{
    //    public string firstName;
    //    public string lastName;
    //    public int age;
    //    public bool ismarriage;

    //    public Person(string _firstName, string _lastName, int _age, bool _ismarriage)
    //    {
    //        firstName = _firstName;
    //        lastName = _lastName;
    //        age = _age;
    //        ismarriage = _ismarriage;
    //    }
    //}
}
