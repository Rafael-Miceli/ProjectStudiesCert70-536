using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2L2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1
            /*
            MemoryStream ms = new MemoryStream();

            StreamWriter sw = new StreamWriter(ms);

            Console.WriteLine("Enter 'quit' on a blank line to exit.");
            while (true)
            {                
                string input = Console.ReadLine();

                if (input == "quit")
                    break;

                sw.WriteLine(input);
            }

            sw.Flush();

            FileStream fs = new FileStream(@"C:\output.txt", FileMode.Create);
            ms.WriteTo(fs);

            sw.Close();
            fs.Close();
            ms.Close();

            TextReader tr = new StreamReader(@"C:\output.txt");

            Console.WriteLine(tr.ReadToEnd());

            tr.Close();

            //TextWriter tw = new FileStream();

            //TextReader tr = new StreamWriter();
            */ 


            //Exercise 2
                        
            MemoryStream ms = new MemoryStream();

            StreamWriter sw = new StreamWriter(ms);

            Console.WriteLine("Enter 'quit' on a blank line to exit.");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "quit")
                    break;

                sw.WriteLine(input);
            }

            sw.Flush();

            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("output.txt", FileMode.Create, FileAccess.ReadWrite, isf);

            ms.WriteTo(isfs);

            sw.Close();
            isfs.Close();
            ms.Close();


            IsolatedStorageFileStream readisfs = new IsolatedStorageFileStream("output.txt", FileMode.Open, FileAccess.ReadWrite, isf);
            TextReader tr = new StreamReader(readisfs);

            Console.WriteLine(tr.ReadToEnd());

            tr.Close();
            

            Console.ReadKey();            
        }
    }
}
