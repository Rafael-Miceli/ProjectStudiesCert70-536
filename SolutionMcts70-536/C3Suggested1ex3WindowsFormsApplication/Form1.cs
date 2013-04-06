using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace C3Suggested1ex3WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Valid = false;

            //Name
            if (Regex.IsMatch(textBox1.Text, @"^([A-Z])([a-z]+)\s([a-z]+\s)?([A-Z])([a-z]+)$") && Regex.IsMatch(textBox3.Text, @"^(\w+(\s)?)*,\s\d+$") && Regex.IsMatch(textBox2.Text, @"^\(\d\d\)\s?(\d\d\d\d)-?(\d\d\d\d)$"))
                Valid = true;
            //Address
            //Valid = Regex.IsMatch(textBox3.Text, @"^(\w+(\s)?)*,\s\d+$");
            //Phone
            //Valid = Regex.IsMatch(textBox2.Text, @"^\(\d\d\)\s?(\d\d\d\d)-?(\d\d\d\d)$");

            if (Valid)
                panel1.BackColor = Color.Green;
            else
                panel1.BackColor = Color.Red;
        }
    }
}
