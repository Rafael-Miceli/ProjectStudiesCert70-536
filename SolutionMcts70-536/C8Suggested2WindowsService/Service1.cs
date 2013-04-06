using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;

namespace C8Suggested2WindowsService
{
    public partial class ServiceSuggested1:ServiceBase
    {
        /*
        private Timer t = null; 
        
        void  t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                //Send the HTTP request
                string url = "http://www.microsoft.com";

                //WebRequest wg = WebRequest.Create("http://www.microsoft.com");
                //WebResponse wr = wg.GetResponse();                

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

            }
            catch(Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Exception: " + ex.Message);
                EventLog.WriteEntry(ex.Message);
                throw;
            }
        }
        */
        FileSystemWatcher fsw = new FileSystemWatcher(@"C:\");

        public ServiceSuggested1()
        {
            InitializeComponent();

            //Não aceita Streams            
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
            fsw.Filter = "*.config";
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);

            
            //t = new Timer(10000);
            //t.Elapsed += new ElapsedEventHandler(t_Elapsed);
        }

        void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            string s;
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                using(TextReader tr = new StreamReader(e.FullPath))
                { 
                    while(tr.Peek() > -1)
                    {
                        s = tr.ReadLine();
                        if (s.Contains("Teste"))
                        {
                            if (s.Contains("No"))
                            {
                                System.Diagnostics.EventLog eve = new EventLog("ConfigAcess");
                                eve.Source = "Service";
                                eve.WriteEntry("Seurity Changed", EventLogEntryType.Warning);            
                            }
                            else
                            {
                                System.Diagnostics.EventLog eve = new EventLog("ConfigAcess");
                                eve.Source = "Service";
                                eve.WriteEntry("Changed config file", EventLogEntryType.Information);            
                            }
                        }
                    }
                }
            }
            
            //throw new NotImplementedException();
        }

        protected override void OnStart(string[] args)
        {
            //t.Start();
            fsw.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            //t.Stop();
            fsw.EnableRaisingEvents = false;
        }

        protected override void OnPause()
        {
            //base.OnPause();
            //t.Stop();
            fsw.EnableRaisingEvents = false;
        }

        protected override void OnContinue()
        {
            //base.OnContinue();
            //t.Start();
            fsw.EnableRaisingEvents = true;
        }

        protected override void OnShutdown()
        {
            //base.OnShutdown();
            //t.Stop();
            fsw.EnableRaisingEvents = false;
        }
    }
}
