using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace C4L1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();

            al.Add(new ShoppinCartItem("Car", 5000));
            al.Add(new ShoppinCartItem("Book", 30));
            al.Add(new ShoppinCartItem("Phone", 80));
            al.Add(new ShoppinCartItem("Computer", 1000));

            al.Sort();

            foreach(ShoppinCartItem item in al)
            {
                Console.WriteLine(item.ItemName + " " + item.Price);
            }

            al.Reverse();

            foreach(ShoppinCartItem item in al)
            {
                Console.WriteLine(item.ItemName + " " + item.Price);
            }

            Console.ReadKey();
        }
    }

    public class ShoppinCartItem: IComparable
    {
        public string ItemName;
        public double Price;

        public ShoppinCartItem(string _Itemname, double _Price)
        {
            ItemName = _Itemname;
            Price = _Price;
        }

        int IComparable.CompareTo(object obj)
        {
            ShoppinCartItem otherItem = (ShoppinCartItem)obj;
            return this.Price.CompareTo(otherItem.Price);
        }
    }
}
