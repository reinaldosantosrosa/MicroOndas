using MicroOndas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.View
{
    public partial class Inserir : Form
    {
        private Programa p;
        private TodosPrograma dominio = new TodosPrograma();

        public Inserir()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            decimal tempo = decimal.Parse(textBox2.Text);
            int potencia = int.Parse(textBox3.Text);
            string instrucoes = textBox5.Text;
            List<string> alimentos = textBox4.Lines.ToList<string>();
            char c = textBox6.Text[0];

            p = new Programa(tempo, alimentos, potencia, c, nome, instrucoes);

            dominio.CadastraPrograma(p);

            Form1 f = new Form1();
            f.Focus();
           
            this.Close();
        }


    }
}
