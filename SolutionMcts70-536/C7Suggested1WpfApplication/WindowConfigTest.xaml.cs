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
using System.Configuration;

namespace C7Suggested1WpfApplication
{
    /// <summary>
    /// Interaction logic for WindowConfigTest.xaml
    /// </summary>
    public partial class WindowConfigTest:Window
    {
        public WindowConfigTest()
        {
            InitializeComponent();
            
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            Configuration con = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ClassCustomConfig customconfig = (ClassCustomConfig)con.GetSection("CustomConfig");

            customconfig.Value = double.Parse(txtValue.Text);
            customconfig.Age = int.Parse(txtAge.Text);
            customconfig.Name = txtName.Text;

            con.Save(ConfigurationSaveMode.Modified);
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            ClassCustomConfig custoconfig = (ClassCustomConfig)ConfigurationManager.GetSection("CustomConfig");

            txtAge.Text = custoconfig.Age.ToString();
            txtName.Text = custoconfig.Name;
            txtValue.Text = custoconfig.Value.ToString();
        }
    }
}
