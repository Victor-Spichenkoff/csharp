using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    //entrada == nome do elemento screen1
    public partial class F_Principal : Form//classe base
    {
        public F_Principal()//contrutor
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newVeiculo = inputName.Text;
            if (newVeiculo == "")
            {
                MessageBox.Show("Escreve algo, animal!");
                inputName.Focus();
                return;
            }

            lista.Text += $"{newVeiculo}";
            inputName.Text = "";
            inputName.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lista.Text = "";
            inputName.Focus();
        }
    }
}
