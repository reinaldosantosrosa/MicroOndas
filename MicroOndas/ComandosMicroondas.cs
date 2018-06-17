using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas
{
    class ComandosMicroondas: IComandosMicroondas

    {

        private readonly IMicroOndasRepository microOndaRepository;


        public ComandosMicroondas(IMicroOndasRepository produtoRepository)
        {
           
            this.microOndaRepository = produtoRepository;
        }

        public void Liga()
        {

            
        }

        public void GetParametros()
        {

        }

    }
}
