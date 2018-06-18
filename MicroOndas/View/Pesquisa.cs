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
    public partial class Pesquisa : Form
    {
        private Programa p;
        private TodosPrograma dominio = new TodosPrograma();
        private int indicePrograma;

        public Pesquisa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string texto = textBox2.Text;
            p = dominio.PesquisaAlimento(texto);
            if (p != null)
            {
                ShowPrograma(p);
            } else
            {
                MessageBox.Show("Alimento inválido");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicePrograma = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = dominio.ShowPrograma(indicePrograma);
            ShowPrograma(p);
        }

        private void ShowPrograma(Programa entrada)
        {
            label6.Text = p.NomePrograma;
            label6.Visible = true;
            label7.Text = p.Potencia.ToString();
            label7.Visible = true;
            label8.Text = p.Tempo.ToString();
            label8.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = p.Instrucao;
            listView1.Items.Clear();
            foreach (var item in p.Alimentos)
            {
                listView1.Items.Add(item);
            }
        }
    }
}
