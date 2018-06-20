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
        public  IMicroOndasRepository produtoRepository;
               
        int indicePrograma;
        private TodosPrograma p = new TodosPrograma();

        LancaExececaoNegocio2 lancaExcecao = new LancaExececaoNegocio2();
        

        public Form1()
        {
            InitializeComponent();



            //lancaExcecao.NomeExcecao += new LancaExececaoNegocio.LancaExcecao(Exibe_Mensagem);

        }

        private void Exibe_Mensagem(string ex)
        {
            MessageBox.Show(ex);
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

                if (((Convert.ToDecimal(tempo) < (1 / 100)) || (Convert.ToDecimal(tempo) > 2) || (Convert.ToDecimal(tempo) < 0)))

                {
                // MessageBox.Show("Campo tempo invalido");
                

                    try
                    {
                      //  throw new MyException(MyException.MsgDefinida(1));
                    throw new TrataExcecao("teste");
                    }
                    catch (TrataExcecao ex)
                    {
                        MessageBox.Show(ex.Message);


                    }

                   // throw new TrataExcecao("t");


                    //  this.textBox2.Focus();
                }
            
        

             
            if ((int.Parse(potencia) == 0) || (int.Parse(potencia) > 10))
            {
                MessageBox.Show("Campo potencia deve ser informado valor de 1 a 10");
                this.textBox1.Focus();
            }
         
               Micro_Ondas mc = new Micro_Ondas(Convert.ToDecimal(tempo), int.Parse(potencia), this.textBox3.Text);


                try
                {
                    // this.textBox3.Text = produtoRepository.Aquecer(int.Parse(this.textBox2.Text), int.Parse(this.textBox1.Text), this.textBox3.Text);


                  
                    MicroOndasRepository produtoRepository = new MicroOndasRepository();
                    
                    produtoRepository.Aquecido += new MicroOndasRepository.EventoAquecido(Fim_Aquecimento);

                    this.textBox3.Text = produtoRepository.Aquecer(mc.Tempo, mc.Potencia, mc.Alimento, '.');



                }
                catch  (Exception ex)
                {
                           Exibe_Mensagem(ex.Message);
                }
            
        }        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
            

                MessageBox.Show(p.UsePrograma(indicePrograma, textBox3.Text));
                MessageBox.Show("aquecido");

                
                    


            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
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
            Inserir inserir = new Inserir();
            inserir.ShowDialog();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            p.Update();
            comboBox1.Items.Clear();
            foreach(var programa in p.GetProgramas())
            {
                comboBox1.Items.Add(programa.NomePrograma);
            }
        }

    void Fim_Aquecimento()
        {
            MessageBox.Show("Aquecido");
        }


    }


   
    }
