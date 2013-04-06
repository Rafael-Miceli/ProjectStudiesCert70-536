using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace C7Suggested1WpfApplication
{
    /// <summary>
    /// Interaction logic for WindowPi.xaml
    /// </summary>
    public partial class WindowPi:Window
    {
        public decimal CurrentValue;
        public ResultCalcPI callbackPI;

        public WindowPi()
        {
            InitializeComponent();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            ContinueCalcPI = false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            callbackPI = new ResultCalcPI(ExhibPI);
            Thread t = new Thread(new ThreadStart(Calculate));
            t.Start();

            if (!ContinueCalcPI)
            {
                t.Abort();
            }

            //ThreadPool.QueueUserWorkItem(Calculate);
        }

        bool ContinueCalcPI = true;

        // Pi/4 = 1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 .....
        public void Calculate()
        {
            decimal CurrentPI = 1;

            try
            {                            
                var multiplier = 1;
                var nextnumber = 3;

                decimal result = 1;
                while(ContinueCalcPI)
                {
                    multiplier = multiplier * -1;
                    result = result + multiplier * (decimal)1 / (nextnumber);
                    CurrentPI = result * 4;

                    nextnumber += 2;

                    callbackPI(CurrentPI);
                }               

            }
            catch(ThreadAbortException ex)
            {
                callbackPI(CurrentPI);
                throw;
            }
            //return CurrentPI;
        }

        public void ExhibPI(decimal PI)
        {
            CurrentValue = PI;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            txbPi.Text = CurrentValue.ToString();
        }
    }

    public delegate void ResultCalcPI(decimal PI);
}
