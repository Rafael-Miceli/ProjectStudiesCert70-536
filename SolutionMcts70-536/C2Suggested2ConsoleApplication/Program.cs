using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace C2Suggested2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();           

            IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("binPath", FileMode.OpenOrCreate, FileAccess.ReadWrite, isf);

            try
            {
                using (BinaryReader binreader = new BinaryReader(isfs))
                {
                    int BinPeek = binreader.PeekChar();
                    while (BinPeek > 0)
                    {
                        Int64 ID = binreader.ReadInt32();
                        string Name = binreader.ReadString();

                        Console.WriteLine("Readed binary = " + ID.ToString() + " " + Name);
                        BinPeek = binreader.PeekChar();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isfs.Close();
                Console.ReadKey();
            }
            
            
            Person p = new Person(2, "Pri", 21, DateTime.Parse("27/11/1990"));
            isfs = new IsolatedStorageFileStream("binPath", FileMode.OpenOrCreate, FileAccess.ReadWrite, isf);

            try
            {
                BinaryWriter binwriter = new BinaryWriter(isfs);

                binwriter.Write(p.ID);
                binwriter.Write(p.Name);
                binwriter.Write(p.Age);
                binwriter.Write(p.Birth.ToString());

                binwriter.Flush();
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                isfs.Close();
                Console.ReadKey();
            }
        }
    }

    class Person
    {
        public int ID;
        public string Name;
        public int Age;
        public DateTime Birth;

        public Person(int _id, string _name, int _age, DateTime _birth)
        {
            ID = _id;
            Name = _name;
            Age = _age;
            Birth = _birth;
        }
    }
}
