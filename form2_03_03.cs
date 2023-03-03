using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Color EditorBackColor
        {
            get
            {
                return labelTest.BackColor;
            }
            set
            {
                labelTest.BackColor = value;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonbackcolor_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.Color = EditorBackColor;
            if(CD.ShowDialog() == DialogResult.OK)
            {
                labelTest.BackColor = CD.Color;
            }
        }

        private void buttonFontSize_Click(object sender, EventArgs e)
        {
            int FontSize = Convert.ToInt32(textBox1.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
