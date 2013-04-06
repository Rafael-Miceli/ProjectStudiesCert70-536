using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C1Suggested3ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            EventArgs e = new EventArgs();
            
        }
        
        public event MyEventHandler MyEvent; 

        public delegate void MyEventHandler(object sender, EventArgs e);
    }

    public delegate void MyEventHandler2(object sender, EventArgs e, string teste);

    class Eventtest
    {
        public delegate void MyEventHandler3(object sender, EventArgs e);

        public event MyEventHandler2 eventmine;

        public void testemethod()
        {
            EventArgs e = new EventArgs();

            if(eventmine != null)
            {
                eventmine(this, e, "");
            }
        }
    }
}
