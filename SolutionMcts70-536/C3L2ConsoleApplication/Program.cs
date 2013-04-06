using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C3L2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\rafael\Documents\Credenciais Apex.txt"))
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\rafael\Documents\Credenciais Apex code.txt", false, Encoding.UTF7))
                    {
                        sw.WriteLine(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
