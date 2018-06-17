using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    internal class MicroOndasRepository: IMicroOndasRepository
    {

        
        private string txtTexto = "";
        private string txtPonto = "";
        private int _tempo;


    
        public string Aquecer(decimal Tempo, int Potencia, string Texto, char c)
        {

            do
            {
                _tempo++;

                for (int i = 0 ; i < Potencia; i++)
                {
                    txtPonto = txtPonto + c;
                }

            }while (_tempo < (Tempo < 1 ? (Tempo*100):( Tempo*60 )));

            Texto = Texto + txtPonto;

            return Texto;

            
        }

        //string IMicroOndasRepository.Aquecer(decimal Tempo, int Potencia, string Texto, char c)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
