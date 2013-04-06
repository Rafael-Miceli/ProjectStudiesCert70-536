using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C2L1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1

            /*Console.WriteLine("Drives: ");

            foreach(DriveInfo item in DriveInfo.GetDrives())
            {
                Console.WriteLine("  {0} ({1})", item.Name, item.DriveType);
            }

            Console.WriteLine("\n Press a letter to view files and folders.");
            ConsoleKeyInfo drive = Console.ReadKey(true);

            DirectoryInfo dirinfo = new DirectoryInfo(drive.Key.ToString() + @":\");

            Console.WriteLine("Folders: ");

            foreach(DirectoryInfo item in dirinfo.GetDirectories())
            {
                Console.WriteLine(" " + item.Name);
            }

            Console.WriteLine("Files: ");

            foreach(FileInfo item in dirinfo.GetFiles())
            {
                Console.WriteLine(" " + item.Name);
            }
            */

            //Exercise 2

            FileSystemWatcher fsw = new FileSystemWatcher(@"D:\GALEGO\\");

            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime;

            ProgramWatcher p = new ProgramWatcher();

            fsw.Created += new FileSystemEventHandler(p.fsw_changed);
            fsw.Deleted += new FileSystemEventHandler(p.fsw_changed);
            fsw.Changed += new FileSystemEventHandler(p.fsw_changed);
            fsw.Renamed += new RenamedEventHandler(p.fsw_renamed);

            Console.WriteLine("Begin watch folder? s/n");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if(key.Key.ToString() == "S")
            {
                fsw.EnableRaisingEvents = true;
                Console.WriteLine("Watching");
            }
            else
            {
                Console.WriteLine("Press any key to finish the program");
            }

            Console.ReadKey();
        }
        
        static void fsw_changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.ChangeType.ToString() + ": " + e.FullPath);
        }

        static void fsw_renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.ChangeType.ToString() + " From " + e.OldName + " To: " + e.Name);
        }
    }

    public class ProgramWatcher
    {
        public void fsw_changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.ChangeType.ToString() + ": " + e.FullPath);
        }

        public void fsw_renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.ChangeType.ToString() + " From " + e.OldName + " To: " + e.Name);
        }
    }
}
