using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Policy;

namespace C8Suggested1DomainConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomainSetup dsetup = new AppDomainSetup();
            dsetup.DisallowCodeDownload = true;
            dsetup.SandboxInterop = false;

            AppDomain d = AppDomain.CreateDomain("Domain teste", null, dsetup);

            object[] hostEvidence = {new Zone(SecurityZone.Intranet)};
            Evidence e = new Evidence(hostEvidence, null);            
            d.ExecuteAssembly(@"C:\Users\Rafa&Pri\Documents\Visual Studio 2010\SolutionMcts70-536\C8Suggested1ConsoleApplication\bin\Debug\C8Suggested1ConsoleApplication.exe");


            Console.WriteLine("Want to unload domain " + d.FriendlyName + "?");
            ConsoleKeyInfo key = Console.ReadKey();

            if(key.KeyChar == 'S')
            {
                AppDomain.Unload(d);
            }
                        
            Console.ReadKey();
        }
    }
}
