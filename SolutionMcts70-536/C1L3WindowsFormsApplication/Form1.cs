using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C1L3WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        Timer t;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            progressBarObj.Maximum = progressBarGen.Maximum = 1000000;
        }

        void t_Tick(object sender, EventArgs e)
        {
            string Timeelapsed;
            
            Timeelapsed = DateTime.Now.Ticks.ToString();
            //lblgeneric.Text = Timeelapsed;
            //lblObject.Text = Timeelapsed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime begin = DateTime.Now;

            //t.Start(); 
            Genericclass<int, string, double> testegeneric = new Genericclass<int, string, double>(2, "testando", 200.2);            

            for(int i = 0; i < 1000000; i++)
            {                
                testegeneric.t += 2;
                testegeneric.u = "testando Nº: " + testegeneric.t.ToString();
                testegeneric.v = 105.33;

                progressBarGen.Value = i + 1;
            }

            TimeSpan elapsedSpan = new TimeSpan(DateTime.Now.Ticks - begin.Ticks);
            lblgeneric.Text = elapsedSpan.TotalSeconds.ToString();

            begin = DateTime.Now;


            objectclass testeobject = new objectclass(2, "testeando", 200.2);

            for(int i = 0; i < 1000000; i++)
            {                
                testeobject.t = (int)testeobject.t + 2;
                testeobject.u = "testando Nº: " + testeobject.t.ToString();
                testeobject.v = (double)testeobject.v + 105.33;

                progressBarObj.Value = i + 1;
            }

            elapsedSpan = new TimeSpan(DateTime.Now.Ticks - begin.Ticks);
            lblObject.Text = elapsedSpan.TotalSeconds.ToString();
        }
    }

    public class Genericclass<T, U, V>
    {
        public T t;
        public U u;
        public V v;

        public Genericclass(T _t, U _u, V _v)
        {
            t = _t;
            u = _u;
            v = _v;
        }
    }



    public class objectclass
    {
        public object t;
        public object u;
        public object v;

        public objectclass(object _t, object _u, object _v)
        {
            t = _t;
            u = _u;
            v = _v;
        }
    }
}
