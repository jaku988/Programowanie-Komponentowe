using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const String MyFilter = "Plik tekstowy|*.txt|Skrypty|*.bat|Wszystkie Pliki|*.*";
        private Boolean Saved = false;
        private string myFileName = "";
        private Boolean isEdited = false;
        public Boolean IsEdited
        {
            get
            {
                return isEdited;
            }
            set
            {
                isEdited = value;
                SetInfo();
            }
        }
        public String MyFileName
        {
            set
            {
                myFileName = value;
                SetInfo();
            }
            get
            {
                return myFileName;
            }

        }

        void SetInfo()
        {
            this.Text = MyFileName;
            if (IsEdited)
            {
                this.Text = "*" + MyFileName;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

        }

        private void zapiszJakoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            zapiszJako();
        }

        private void zapiszJako()
        {
            SaveFileDialog SFDialog = new SaveFileDialog();
            SFDialog.Filter = MyFilter;

            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFDialog.FileName, richTextBox1.Text);
                MyFileName = SFDialog.FileName;
                Saved = true;
                IsEdited = false;
            }
            
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();
            OFDialog.Filter = MyFilter;

            if (OFDialog.ShowDialog() == DialogResult.OK)
            {
               
                richTextBox1.Text = File.ReadAllText(OFDialog.FileName);
                MyFileName = OFDialog.FileName;
                IsEdited = false;
            }
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsEdited)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Plik został zmieniony!", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
                
            Close();
            
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Saved)
            {
                zapiszJako();
            }
            else
            {
                File.WriteAllText(MyFileName, richTextBox1.Text);
                IsEdited = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            IsEdited = true;
        }

        private void edycjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 FC = new Form2();
            FC.EditorBackColor = richTextBox1.BackColor;
            if(FC.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = FC.EditorBackColor;
            }
        }
    }   
}
