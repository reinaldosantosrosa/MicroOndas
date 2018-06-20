using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroOndas.Repositorio;

namespace MicroOndas.Repositorio
{
   public class LancaExececaoNegocio2
    {

        public LancaExececaoNegocio2()
        {
        }

        public void LancaErro(int erro)
        {

            switch(erro)
            {
                case 1: throw new TrataExcecao("Potencia nao pode ser maior que 10");
                case 2: throw new TrataExcecao("Potencia invalida");
                case 3: throw new TrataExcecao("Tempo nao pode ser maior que 2 minutos");
                case 4: throw new TrataExcecao("Tempo não pode ser menor que 1 segundo");
                


            }

            this.NomeExcecao("");
        }

        public delegate void LancaExcecao(string ex);
        //Cria um evento
        public event LancaExcecao NomeExcecao;

    }

   

}
