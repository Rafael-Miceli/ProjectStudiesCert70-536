using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C8Suggested1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using(TextReader tr = new StreamReader(@"C:\Users\Rafa&Pri\Documents\filmes para baixar.txt"))
            {
                string text = tr.ReadToEnd();
            }

            string url = "http://www.microsoft.com";

            HttpWebRequest g = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            using(HttpWebResponse r = (HttpWebResponse)g.GetResponse())
            {
                //Log the response to a text file
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt";
                using(TextWriter tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(DateTime.Now.ToString() + " for " + url + ": " + r.StatusCode.ToString());
                }
            }

            string LargeAmuntOfMemory = "Large";

            for(int i = 0; i < 10000; i++)
            {
                LargeAmuntOfMemory += "large Amount N°" + i.ToString();
                Console.WriteLine("Creating amount " + i.ToString());
            }

            //Console.ReadKey();

        }
    }
}
