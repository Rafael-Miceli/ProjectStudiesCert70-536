using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace C3Suggested1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            //Exercise 1
            /*
            StringBuilder sb = new StringBuilder();
            string line;

            using (FileStream fs = new FileStream(@"C:\Windows\teste.txt", FileMode.Open, FileAccess.Read))
            {
                TextReader tr = new StreamReader(fs);   

                while ((line = tr.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, @"Exit code"))
                    {
                        Match mtHour = Regex.Match(line, @"([0-1][0-9]|[2][0-3])(:[0-5][0-9])(:[0-5][0-9])(:[0-9][0-9][0-9])");
                        Match mtDate = Regex.Match(line, @"^(\d{4}-\d{2}-\d{2})+");
                        Match mtExitCode = Regex.Match(line, @"Exit code = (?<code>(0x\d*)(\w)?)(])?");
                        sb.AppendLine(mtDate.Value + " " + mtHour.Value + " " + mtExitCode.Groups["code"]);                       
                    }
                }                
            }

            Console.WriteLine(sb.ToString());

            */

            //Exercise 2
            StringBuilder sb = new StringBuilder();

            using (TextReader tr = new StreamReader(@"C:\Windows\teste.txt"))
            {                
                string line;

                while ((line = tr.ReadLine()) != null)
                {
                    sb.AppendLine(Regex.Replace(line, @"^\d\d(?<year>(\d\d))-(?<month>([0][0-9]|[1][0-2]))-(?<day>([0-2][0-9]|[3][0-1]))", "${month}-${day}-${year}"));
                }
            }

            if (sb.ToString() != null || sb.ToString() != "")
            {
                using (TextWriter tw = new StreamWriter(@"C:\Users\rafael\Documents\new date.txt"))
                {
                    tw.Write(sb.ToString());        
                }                 
            }            

            /*DateTime date1 = DateTime.Now;

            DateTime date2 = DateTime.ParseExact("02/03/2012", "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact("02:03:00", "hh/mm/ss", null);
            TimeSpan date3 = date1 - date2;

            Console.WriteLine(date3.Days);*/

            Console.ReadKey();
        }
    }
}
