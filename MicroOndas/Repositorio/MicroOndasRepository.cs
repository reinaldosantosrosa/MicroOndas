using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    public class MicroOndasRepository : IMicroOndasRepository
    {

        public Boolean c_Sai { get; set; }

        private string txtPonto = "";
        private decimal _tempo;

        decimal _Tempo2;
        int _Potencia;
        string _Texto;
        char _c;

        public MicroOndasRepository()
        {
            
        }

        public MicroOndasRepository(Boolean condicao)
        {
            this.c_Sai = condicao;
        }


        public MicroOndasRepository(decimal qtdTempo, decimal Tempo, int Potencia, string Texto, char c)
        {
            this._tempo = qtdTempo;
            this._Tempo2 = Tempo;
            this._Potencia = Potencia;
            this._Texto = Texto;
            this._c = c;

        }

        //decimal Tempo, int Potencia, string Texto, char c

        /// <summary>
        /// 
        /// </summary>
        public void Aquecer()
        {

            try
            {
                do
                {
                    Thread.Sleep(1000);

                    _tempo++;

                   // for (int i = 0; i < _Potencia; i++)
                    //{
                    //    txtPonto = txtPonto + _c;
                 //   }



                } while (_tempo < (_Tempo2 < 1 ? (_Tempo2 * 100) : (_Tempo2 * 60)));
            }
            catch (ThreadAbortException abortException)
            {
               System.Windows.Forms.MessageBox.Show(((string)abortException.ExceptionState));
            }

            this.Aquecido();


            //return _Texto;
            
            
        }


        public string getTexto()
        {
            return _Texto+txtPonto;
        }

        public delegate void EventoAquecido();
        //Cria um evento
        public event EventoAquecido Aquecido;

 


    }






}




