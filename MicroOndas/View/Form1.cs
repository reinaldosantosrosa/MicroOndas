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

namespace MicroOndas
{
    public partial class Form1 : Form
    {
        private  IMicroOndasRepository produtoRepository;
        

        private string Texto;

       

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
            tempo = this.textBox2.Text.Replace(".", ",");

          if  ((tempo == "") || (  Convert.ToDecimal(tempo) < (1/100) ) || (Convert.ToDecimal(tempo) > 2) || (Convert.ToDecimal(tempo) <=0))
           
            {
                MessageBox.Show("Campo tempo invalido");
                this.textBox2.Focus();
            }
            else
            if ((this.textBox1.Text== "") || (int.Parse(this.textBox1.Text) == 0) || (int.Parse(this.textBox1.Text) > 10))
            {
                MessageBox.Show("Campo potencia deve ser informado valor de 1 a 10");
                this.textBox1.Focus();
            }
            else
            {

                produtoRepository = new MicroOndasRepository();
                               

                Micro_Ondas mc = new Micro_Ondas(Convert.ToDecimal(tempo), int.Parse(this.textBox1.Text), this.textBox3.Text);

                // this.textBox3.Text = produtoRepository.Aquecer(int.Parse(this.textBox2.Text), int.Parse(this.textBox1.Text), this.textBox3.Text);
                this.textBox3.Text = produtoRepository.Aquecer(mc.Tempo, mc.Potencia, mc.Alimento);

            }
        }
            

            
        

     
    }
}
