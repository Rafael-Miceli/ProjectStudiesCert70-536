using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace C7L1ConsoleApplication
{
    
	class Program
	{
        [MTAThread]
		static void Main(string[] args)
		{
			string[] urls = { "http://www.microsoft.com",
								"http://www.contoso.com",
								"http://www.msn.com",
								"http://msdn.microsoft.com",
								"http://mspress.microsoft.com" };

			AutoResetEvent[] waithandles = new AutoResetEvent[urls.Length];

			// Record the time before we start
			DateTime beginTime = DateTime.Now;

			// Retrieve each page
			for (int i = 0; i < urls.Length; i++)
			{
				waithandles[i] = new AutoResetEvent(false);
				PageSize ps = new PageSize(urls[i], waithandles[i], new ResultDelegate(ResultCallback));
                Thread t = new Thread(new ThreadStart(ps.GetPageSize));
                t.Name = "Thread" + (i + 1).ToString();
                t.Start();
				//ThreadPool.QueueUserWorkItem(GetPage, ti);
			}
				
			//Wait all the events
            WaitHandle.WaitAll(waithandles);

			// Display the elapsed time
			Console.WriteLine("Time elapsed: " + (DateTime.Now - beginTime).ToString());
			Console.WriteLine("Press a key to continue");
			Console.ReadKey();
		}

        static void ResultCallback(PageSize ps)
        {
            Console.WriteLine("{0}: {1}", ps.url, ps.bytes.ToString());
        }

        /*
		static void GetPage(object data)
		{
			//Cast the object to a string
			//string url = (string)data;

			//Cast the object to a ThreadInfo
			PageSize ti = (PageSize)data;

			// Request the URL
			WebResponse wr = WebRequest.Create(ti.url).GetResponse();

			// Display the value for the Content-Length header
			Console.WriteLine(ti.url + ": " + wr.Headers["Content-Length"]);

			wr.Close();

			// Let the Parent thread know the process is done
			ti.are.Set();
		}     
        */
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ps"></param>
    delegate void ResultDelegate(PageSize ps);

	class PageSize
	{
		public string url;
		public AutoResetEvent are;
        public int bytes;

        //Delegate used to execute the callback method when the task is complete
        ResultDelegate Callback;

		public PageSize(string _url, AutoResetEvent _are, ResultDelegate _callback)
		{
			url = _url;
			are = _are;
            Callback = _callback;
		}

        public void GetPageSize()
        {   
            //Request the URL
            WebResponse wr = WebRequest.Create(url).GetResponse();

            bytes = int.Parse(wr.Headers["Content-Length"]);

            // Display the value for the Content-Length header
            //Console.WriteLine(url + ": " + bytes.ToString());

            wr.Close();

            Callback(this);

            // Let the Parent thread know the process is done
            are.Set();
        }
         
	}
}
