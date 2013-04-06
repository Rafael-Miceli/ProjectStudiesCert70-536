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
using System.IO;
using C2Suggested1WpfApplication.Model;

namespace C2Suggested1WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ItemProvider itemprovider = new ItemProvider();

            List<Item> items = itemprovider.GetItems(@"D:\Rafael\Estudos");

            DataContext = items;
        }
    } 

    public class ItemProvider
    {
        public List<Item> GetItems(string path)
        {
            List<Item> items = new List<Item>();

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo directory in dirInfo.GetDirectories())
            {
                DirectoryItem item = new DirectoryItem
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetItems(directory.FullName)
                };

                items.Add(item);
            }

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                FileItem item = new FileItem
                {
                    Name = file.Name,
                    Path = file.FullName
                };

                items.Add(item);
            }

            return items;
        }
    }

}

namespace C2Suggested1WpfApplication.Model
{
    public class Item
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }


    public class FileItem: Item
    {
        
    }

    public class DirectoryItem: Item
    {
        public List<Item> Items { get; set; }

        public DirectoryItem()
        {
            Items = new List<Item>();
        }
    }
}
