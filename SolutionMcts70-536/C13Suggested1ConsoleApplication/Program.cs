using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace C13Suggested1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class WraperProgram
    {
        
    }

    //[ComVisible(true)]
    public class AcessFromCom
    {
        [ComVisible(false)]
        public int c;

        public AcessFromCom()
        {
        }

        public void MakeCalc(int a, int b)
        {
            c = a * b;

            using (TextWriter tw = new StreamWriter("C:\testeCOM.txt"))
            {
                tw.WriteLine("Prepare for calculation!");

                tw.WriteLine(c);
            }            
        }

        [return: MarshalAs(UnmanagedType.LPTStr)]
        public string GetStr(string s)
        {
            s += " Concatenado";

            return s;
        }
    }
}
