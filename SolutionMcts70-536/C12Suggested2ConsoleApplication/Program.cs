using System;
using System.Security.Principal;
using System.Security.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C12Suggested2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericIdentity genid = new GenericIdentity("Rafael", "");
            Console.WriteLine(genid.IsAuthenticated.ToString());
            
            Console.ReadKey();
        }
    }
}
