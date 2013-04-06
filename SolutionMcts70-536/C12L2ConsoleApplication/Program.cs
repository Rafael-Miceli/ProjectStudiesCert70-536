using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Security.Policy;
using System.Security.AccessControl;

namespace C12L2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorySecurity ds = new DirectorySecurity();
            ds.AddAccessRule(new FileSystemAccessRule("Rafa&Pri", FileSystemRights.Read, AccessControlType.Allow));
            string newFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rafa&Pri");
            Directory.CreateDirectory(newFolder, ds);

            FileSecurity fs = new FileSecurity();
            fs.AddAccessRule(new FileSystemAccessRule("Rafa&Pri", FileSystemRights.FullControl, AccessControlType.Allow));
            string newFile = Path.Combine(newFolder, "Data.dat");
            File.Create(newFile, 100, FileOptions.None, fs);
        }
    }
}
