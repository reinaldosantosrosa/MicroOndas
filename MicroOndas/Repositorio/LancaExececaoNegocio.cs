using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroOndas.Repositorio;

namespace MicroOndas.Repositorio
{
   public class LancaExececaoNegocio
    {

        public LancaExececaoNegocio()
        {
        }

        public string LancaErro(int erro)
        {
            
                string msg = "";

            switch (erro)
            {
                case 1:  msg = "Potencia deve ser menor ou igual a 10 e maior que 1";   break;
                case 2: msg = "Valor Inválido. O tempo deve ser menor ou igual a 2 minutos e maior ou igual a 1 segundo";break;
                case 3: msg = "Alimento invalido"; break;
           

            }

            
            return msg;
          
            
        }

    

    }

   

}
