using System;
using System.Security;
using System.Security.Policy;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C8L1AppDomainConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {           

            //Create an Evidence object for the internet zone
            object[] hostEvidence = {new Zone(SecurityZone.Internet)};
            Evidence e = new Evidence(hostEvidence, null);

            AppDomain d = AppDomain.CreateDomain("MyDomain", e);

            d.ExecuteAssemblyByName("C8L1ConsoleApplication");

            //d.ExecuteAssembly(@"C:\Users\Rafa&Pri\Documents\Visual Studio 2010\Projetos de Estudos\SolutionMcts70-536\C8L1ConsoleApplication\bin\Debug\C8L1ConsoleApplication.exe");

            Console.ReadKey();
        }
    }
}
