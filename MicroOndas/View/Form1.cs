using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroOndas.Modelo;
using MicroOndas.View;

namespace MicroOndas
{
    public partial class Form1 : Form
    {
        private  IMicroOndasRepository produtoRepository;
        

        private string Texto;
        int indicePrograma;
        private TodosPrograma p = new TodosPrograma();

        public Form1()
        {
            InitializeComponent();


        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string tempo = "";
            string potencia = "";

            tempo = this.textBox2.Text.Replace(".", ",");
            potencia = this.textBox1.Text;

            if ((this.textBox2.Text == "") && (this.textBox1.Text == ""))
            {
                tempo = "0,30";
                potencia = "8";
            }

            if  ((  Convert.ToDecimal(tempo) < (1/100) ) || (Convert.ToDecimal(tempo) > 2) || (Convert.ToDecimal(tempo) <0))
           
            {
                MessageBox.Show("Campo tempo invalido");
                this.textBox2.Focus();
            }
            else
            if ((int.Parse(potencia) == 0) || (int.Parse(potencia) > 10))
            {
                MessageBox.Show("Campo potencia deve ser informado valor de 1 a 10");
                this.textBox1.Focus();
            }
            else
            {

                produtoRepository = new MicroOndasRepository();
                               
                Micro_Ondas mc = new Micro_Ondas(Convert.ToDecimal(tempo), int.Parse(potencia), this.textBox3.Text);
                try
                {
                    // this.textBox3.Text = produtoRepository.Aquecer(int.Parse(this.textBox2.Text), int.Parse(this.textBox1.Text), this.textBox3.Text);
                    this.textBox3.Text = produtoRepository.Aquecer(mc.Tempo, mc.Potencia, mc.Alimento, '.');
                    MessageBox.Show("aquecido");
                }
                catch(Exception ex)  
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                // this.textBox3.Text = produtoRepository.Aquecer(int.Parse(this.textBox2.Text), int.Parse(this.textBox1.Text), this.textBox3.Text);
                // this.textBox3.Text = produtoRepository.Aquecer(mc.Tempo, mc.Potencia, mc.Alimento, '.');
                try
                {
                    MessageBox.Show(p.UsePrograma(indicePrograma, textBox3.Text));
                    MessageBox.Show("aquecido");
                } catch(System.ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicePrograma = comboBox1.SelectedIndex;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Pesquisa pesquisa = new Pesquisa();

            pesquisa.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach(var programa in p.GetProgramas())
            {
                comboBox1.Items.Add(programa.NomePrograma);
            }
        }
    }
}
