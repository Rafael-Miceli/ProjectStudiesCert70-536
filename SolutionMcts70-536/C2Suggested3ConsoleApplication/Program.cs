using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace C2Suggested3ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GZipStream gzOut = new GZipStream(File.Create(@"C:\Writing1mb.zip"), CompressionMode.Compress);
            DeflateStream dfOut = new DeflateStream(File.Create(@"C:\Writing1mb2.zip"), CompressionMode.Compress);
            TextWriter tw = new StreamWriter(gzOut);
            TextWriter tw2 = new StreamWriter(dfOut);

            try
            {
                for(int i = 0; i < 1000000; i++)
                {
                    tw.WriteLine("Writing until more than 1mb to ZIP it!");
                    tw2.WriteLine("Writing until more than 1mb to ZIP it!");
                }
            }
            catch(Exception)
            {

                throw;
            }
            finally
            {
                tw.Close();
                gzOut.Close();
                tw2.Close();
                dfOut.Close();
            }

        }
    }
}
