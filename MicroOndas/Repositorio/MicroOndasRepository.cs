using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    public class MicroOndasRepository : IMicroOndasRepository
    {



        private string txtPonto = "";
        private decimal _tempo;

        public MicroOndasRepository()
        {
            
        }

        public MicroOndasRepository(decimal qtdTempo)
        {
            this._tempo = qtdTempo;
        }


        public string Aquecer(decimal Tempo, int Potencia, string Texto, char c)
        {

            do
            {
                _tempo++;
           //     System.Threading.Thread.Sleep(1000);
                for (int i = 0; i < Potencia; i++)
                {
                    txtPonto = txtPonto + c;
                }

            } while (_tempo < (Tempo < 1 ? (Tempo * 100) : (Tempo * 60)));

            Texto = Texto + txtPonto;
            this.Aquecido();

            return Texto;


            
        }

        public delegate void EventoAquecido();
        //Cria um evento
        public event EventoAquecido Aquecido;



    }






}




