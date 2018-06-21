using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MicroOndas.Repositorio
{
    public class TrataExcecao : Exception
    {

        public readonly List<string> Erros;



        public TrataExcecao() : base()
        {
            Erros = new List<string>();
        }

        public TrataExcecao(params string[] erros)
            : this(new List<string>(erros))
        {
           
        }


        public TrataExcecao(IEnumerable<string> erros)
        {

            Erros = new List<string>();
            Erros.AddRange(erros);
            

        }


        public TrataExcecao(String erro, Exception ex)
            : base(erro, ex)
        {
            Erros = new List<string>
            {
                erro
            };
        }

        public string GetErros()
        {
            
            return Erros.Any()
               ? string.Join(", ", Erros)
               : string.Empty;




        }

       

     
    }
}
