using System;
using System.Net;
using System.IO;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace C8L3WindowsService
{
    public partial class MonitorWebSite:ServiceBase
    {
        private Timer t = null; 

        public MonitorWebSite()
        {
            InitializeComponent();

            t = new Timer(10000);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
        }

        public void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                //Send the HTTP request
                string url = "http://www.microsoft.com";

                //WebRequest wg = WebRequest.Create("http://www.microsoft.com");
                //WebResponse wr = wg.GetResponse();                

                HttpWebRequest g = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                using (HttpWebResponse r = (HttpWebResponse)g.GetResponse())
                {
                    //Log the response to a text file
                    string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt";
                    using (TextWriter tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(DateTime.Now.ToString() + " for " + url + ": " + r.StatusCode.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Exception: " + ex.Message);
                EventLog.WriteEntry(ex.Message);
                throw;
            }
            
        }

        protected override void OnStart(string[] args)
        {
            t.Start();
        }

        protected override void OnStop()
        {
            t.Stop();
        }

        protected override void OnPause()
        {
            //base.OnPause();
            t.Stop();
        }

        protected override void OnContinue()
        {
            //base.OnContinue();
            t.Start();
        }

        protected override void OnShutdown()
        {
            //base.OnShutdown();
            t.Stop();
        }
    }
}
