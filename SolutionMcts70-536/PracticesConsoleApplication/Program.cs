using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security.Principal;
using System.Security.Policy;
using System.Globalization;
using System.Drawing;
using System.Configuration;
using System.Data;
using System.Net;

namespace PracticesConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Pegadinha na 70-536 
            Debug.Listeners.Add(new ConsoleTraceListener(true));

            //Errada
            Debug.Print("testin");
            Debug.Print("g");

            //Correta
            Debug.WriteLineIf(true, "testin", "g");
            */




            /*
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(AppDomain.CurrentDomain.Evidence);

            //CodeGroup cg = new FileCodeGroup(,

            WindowsIdentity currentid = WindowsIdentity.GetCurrent();

            Console.WriteLine(currentid.Name);
            Console.WriteLine(currentid.Owner);
            Console.WriteLine(currentid.User);

            WindowsPrincipal principal = new WindowsPrincipal(currentid);

            if (principal.IsInRole(Environment.MachineName + @"\rafael"))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");


            CultureInfo ci = new CultureInfo("", true);

             */ 
            //Font myFont = new Font(,,)




            /*
             * Para funcionar o ConfigurationManager, em Windows forms application o arquivo .config tem que ter o nome App.config
             * Para funcionar o ConfigurationManager, em Web application o arquivo .config tem que ter o nome Web.config
             * 
            string strNameConn = ConfigurationManager.ConnectionStrings["teste"].Name;

            Console.WriteLine(strNameConn);
            */




            /*
            DataSet ds = new DataSet();

            ds.ReadXml(@"C:\Users\rafael\Documents\Visual Studio 2010\Projetos de Estudos\SolutionMcts70-536\XmlDataPractice.xml");
            */              
            

            Console.ReadKey();
        }

        /// <summary>
        /// Tru to Connect to a web URL
        /// </summary>
        /// <returns>Return True if connected, else False</returns>
        public static bool TryWebRequest()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://modulo.com.br/login-mrm/banner3.png");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                return true;
            }
            catch (WebException)
            {
                return false;                
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }

    public class Funcionalidade
    {
        int idFuncionalidade;
        int idOperacao;
    }
}
