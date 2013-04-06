using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace C2Suggested1Pratice2ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //practice 2
            /*
            List<DriveInfo> listdrivers = new List<DriveInfo>();

            List<FileInfo> lstfiles = new List<FileInfo>();    

            //listdrivers.Add(new DriveInfo(@"C:\"));
            //listdrivers.Add(new DriveInfo(@"D:\"));
            listdrivers.Add(new DriveInfo(@"G:\Backup\Estudo\Estudos Rafa\Asp.Net\Projetos de estudo\Infnet 1"));

            foreach (DriveInfo item in listdrivers)
            {
                DirectoryInfo di = new DirectoryInfo(@"G:\Backup\Estudo\Estudos Rafa\Asp.Net\Projetos de estudo\Infnet 1");                

                foreach (DirectoryInfo diItem in di.GetDirectories("*", SearchOption.AllDirectories))
                {
                    foreach (FileInfo Fileitem in diItem.GetFiles())
                    {
                        lstfiles.Add(Fileitem);
                    }
                }
                 
            }

            MaxByteFile mbf = new MaxByteFile();

            lstfiles.Sort(mbf);
            lstfiles.Reverse();

            List<FileInfo> item10 = lstfiles.GetRange(0, 10);

            foreach (FileInfo item in item10)
	        {
                Console.WriteLine(item.Length + "   " + item.FullName);
	        }
            */

            //Practice 3


            DirectoryInfo di = new DirectoryInfo(@"C:\BackupTeste");
            di.Create();

            FileSystemWatcher fsw = new FileSystemWatcher(@"C:\Users\Rafa&Pri\Documents");

            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite;

            fsw.Created += new FileSystemEventHandler(fsw_Created);

            Console.WriteLine("Make Backup?");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if(key.Key == ConsoleKey.S)
            {
                fsw.EnableRaisingEvents = true;
                Console.WriteLine("Watching");
            }

            Console.ReadKey();
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if(e.ChangeType == WatcherChangeTypes.Created)
                {
                    File.Copy(e.FullPath, @"C:\BackupTeste\" + e.Name);
                }
            }
            catch(Exception)
            {
                
                throw;
            }            
        }
    }

    class MaxByteFile : IComparer<FileInfo> 
    {

        int IComparer<FileInfo>.Compare(FileInfo x, FileInfo y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
