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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace C7Suggested1WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [MTAThread]
        private void btnBegin1_Click(object sender, RoutedEventArgs e)
        {
            txbBegin1.Text = "Começando";
            ThreadPool.QueueUserWorkItem(button1);
            if(i > 1000000)
            {
                txbBegin1.Text = i.ToString();    
            }            
            //button1();            
        }

        private void btnBegin2_Click(object sender, RoutedEventArgs e)
        {
            txbBegin2.Text = "testando";
        }

        private void btnBegin3_Click(object sender, RoutedEventArgs e)
        {
            rect3.Fill = Brushes.Black;            
        }

        private int i = 0;

        [MTAThread]
        private void button1(object data)
        {
            
            for(i = 0; i < 1000000000; i++)
            {
                //txbBegin1.Text = i.ToString();
                /*
                TextBlock txb = new TextBlock();
                txb.Text = txb.Name = "txb1" + i.ToString();
                //txb.Margin = new Thickness(0, 0, 30, Left -= 25);
                txb.Width = 120;
                txb.Height = 20;
                //txb.Visibility = System.Windows.Visibility.Visible;
                //Grid.SetColumn(txb, 0);
                //Grid.SetRow(txb, 0);
                //grdMain.Children.Add(txb);
                stk1.Children.Add(txb);
                */ 
            }            
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            WindowPi wpi = new WindowPi();
            wpi.ShowDialog();
        }

        private void btnConfigAppC9Suggested1_Click(object sender, RoutedEventArgs e)
        {
            WindowConfigTest wct = new WindowConfigTest();
            wct.ShowDialog();
        }
    }
}
