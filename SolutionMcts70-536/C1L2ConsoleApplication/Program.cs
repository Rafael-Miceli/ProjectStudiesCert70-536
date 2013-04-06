using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C1L2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercicio 1

            /*
            SByte a = 0;
            Byte b = 0;
            Int16 c = 0;
            Int32 d = 0;
            Int64 e = 0;
            string s = "";
            Exception ex = new Exception();

            object[] types = { a, b, c, d, e, s, ex };

            foreach (object o in types)
            {
                string type;
                if (o.GetType().IsValueType)
                    type = "Is value type";
                else
                    type = "Is Reference type";

                Console.WriteLine("{0}: {1}", o.GetType(), type);                
            } */

            string s = "Microsoft .NET Framework Application Development Foundation";
            string[] sa = s.Split(' ');

            Array.Sort(sa);

            s = string.Join(" ", sa);
            string t = string.Concat(sa);
            t = string.Concat(s, t);

            Console.WriteLine(s);

            Console.WriteLine("\n {0}", t);

            Console.ReadKey();
        }
    }
}
