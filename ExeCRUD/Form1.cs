using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "nabila" && textBox2.Text == "123")
            {
                Form5 mn = new Form5();
                mn.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Pastikan Username dan Password Anda Sudah benar!!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
