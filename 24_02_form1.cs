using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Button b = new Button();
            Button b2;
            b2 = b;

            int x = 2;
        }

        private void buttonDoKlikania_Click_1(object sender, EventArgs e)
        {
            /*
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double suma = x + y;
            textBox3.Text = Convert.ToString(suma);
            */
            bool ok = true;
    
            if(!Double.TryParse(textBox1.Text, out Double x))
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("Popraw w zaznaczonych miejscach!", "Blad!");
                ok = false;
            }
            if (!Double.TryParse(textBox2.Text, out Double y))
            {
                textBox2.BackColor = Color.Red;
                MessageBox.Show("Popraw w zaznaczonych miejscach!", "Blad!");
                ok = false;
            }
            
            
            if (ok)
            {
                textBox1.BackColor = default;
                textBox2.BackColor = default;
                Double wynik;
                switch (listBox.Text)
                {
                    case "+": textBox3.Text = (x + y).ToString(); break;
                    case "-": textBox3.Text = (x - y).ToString(); break;
                    case "*": textBox3.Text = (x * y).ToString(); break;
                    case "/": if (y != 0) textBox3.Text = (x / y).ToString();
                        else textBox3.Text = "Blad!"; break;
                }
               
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
