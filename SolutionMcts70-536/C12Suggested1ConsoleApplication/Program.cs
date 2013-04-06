using System;
using System.IO;
using System.Security.Authentication;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace C12Suggested1ConsoleApplication
{
    class Program
    {
        public static int Main(string[] args)
        {
            string certificate = null;
            string line = null;
            if((line = Console.ReadLine()) == null || Console.ReadLine().Length < 1)
            {
                DisplayUsage();
            }
            certificate = line;
            SslTcpServer.RunServer(certificate);
            return 0;
            
        }

        private static void DisplayUsage()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class SslTcpServer
    {
        static X509Certificate serverCertificate = null;

        public static void RunServer(string certificate)
        {   
            //The certificate parameter specifies the name of the file containing the machine certificate

            serverCertificate = X509Certificate.CreateFromCertFile(certificate);

        }
    }
}
