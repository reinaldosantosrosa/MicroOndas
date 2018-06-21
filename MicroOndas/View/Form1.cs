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
using System.Threading;
using System.IO;

namespace MicroOndas
{
    public partial class Form1 : Form
    {
        public IMicroOndasRepository produtoRepository;

        private int _Potencia_Maxima = 10;

        string tempo = "";
        string potencia = "";

        private List<Programa> programas = new List<Programa>();

        

        int indicePrograma;
        private TodosPrograma p = new TodosPrograma();

        
        int ProcPot;

        LancaExececaoNegocio lancaExcecao = new LancaExececaoNegocio();

        // Declare a System.Threading.CancellationTokenSource.  
        public Thread thread = null;
        

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

            button1.Enabled = false;

            tempo = this.textBox2.Text.Replace(".", ",");
            potencia = this.textBox1.Text;

            //se nao forem iformados o tempo e a potencia, executa de forma automatica
            if ((this.textBox2.Text == "") && (this.textBox1.Text == ""))
            {
                tempo = "0,30";
                potencia = "8";
            }

            if (((Convert.ToDecimal(tempo) < (1 / 100)) || (Convert.ToDecimal(tempo) > 2) || (Convert.ToDecimal(tempo) < 0)))

            {

                
                try
                {
                    throw new TrataExcecao(lancaExcecao.LancaErro(2));
                }
                catch (TrataExcecao ex)
                {
                    var erro = ex.GetErros();
                    if (!string.IsNullOrWhiteSpace(erro))
                        MessageBox.Show(erro);
                }

                
            }




            if ((int.Parse(potencia) == 0) || (int.Parse(potencia) > _Potencia_Maxima))
            {
                try
                {
                    throw new TrataExcecao(lancaExcecao.LancaErro(1));
                }
                catch (TrataExcecao ex)
                {
                    var erro = ex.GetErros();
                    if (!string.IsNullOrWhiteSpace(erro))
                        MessageBox.Show(erro);
                }
            }


            Micro_Ondas mc = new Micro_Ondas(Convert.ToDecimal(tempo), int.Parse(potencia), this.textBox3.Text);

            
            try
            {

                MicroOndasRepository produtoRepository = new MicroOndasRepository(mc.Tempo, mc.Tempo, mc.Potencia, mc.Alimento, '.');

                if (File.Exists(this.textBox3.Text))
                {

                    produtoRepository.Aquecido += new MicroOndasRepository.EventoAquecido(Fim_Aquecimento);

                    string[] dados = System.IO.File.ReadAllLines(this.textBox3.Text );

                    this.textBox3.Text = "";
                    foreach (var item in dados)
                    {
                        var valores = item.Split(' ');

                        thread = new Thread(new ThreadStart(produtoRepository.Aquecer));
                        thread.Start();

                        if (valores[1]!="")
                               Processa_Potencia(mc.Potencia, mc.Tempo,  valores[1]);

                       
                    }

                    //processa arquivos
                }
                else
                {
                    produtoRepository.Aquecido += new MicroOndasRepository.EventoAquecido(Fim_Aquecimento);

                    thread = new Thread(new ThreadStart(produtoRepository.Aquecer));
                    thread.Start();

                    Processa_Potencia(mc.Potencia, mc.Tempo,".");
                }

            }

            catch (Exception ex)
            {
               
                Exibe_Mensagem(ex.Message);

            }

            button1.Enabled = true;


        }

        private void Processa_Potencia(int potencia, decimal tempo, string cCaracter)
        {
            do
            {
                ProcPot++;

              

                for (int i = 0; i < potencia; i++)
                {
                    textBox3.Text = textBox3.Text + cCaracter;

                }
            } while (ProcPot < (tempo < 1 ? (tempo * 100) : (tempo * 60)));
        }


        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                
                p.UsePrograma(indicePrograma, textBox3.Text);

                programas = p.GetProgramas();

              //  Micro_Ondas mc = new Micro_Ondas(Convert.ToDecimal(tempo), int.Parse(potencia), this.textBox3.Text);

                MicroOndasRepository produtoRepository = new MicroOndasRepository(programas[indicePrograma].Tempo, programas[indicePrograma].Tempo, programas[indicePrograma].Potencia, programas[indicePrograma].Alimento, programas[indicePrograma].C);


                produtoRepository.Aquecido += new MicroOndasRepository.EventoAquecido(Fim_Aquecimento);

                
                thread = new Thread(new ThreadStart(produtoRepository.Aquecer));
                thread.Start();

                Processa_Potencia(programas[indicePrograma].Potencia, programas[indicePrograma].Tempo,  programas[indicePrograma].C.ToString());


             //   MessageBox.Show("aquecido");

            }
            catch (TrataExcecao ex)
            {
                var erro = ex.GetErros();
                if (!string.IsNullOrWhiteSpace(erro))
                    MessageBox.Show(erro);
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
            foreach (var programa in p.GetProgramas())
            {
                comboBox1.Items.Add(programa.NomePrograma);
            }
        }

        void Fim_Aquecimento()
        {
           
            MessageBox.Show("Aquecido");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thread.Abort("operação cancelada");

            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Pausar")
            {
                this.button5.Text = "Continuar";

                thread.Suspend();
                
            }
            else
            {
                this.button5.Text = "Pausar";
                thread.Resume();
            }
        }
    }



}
