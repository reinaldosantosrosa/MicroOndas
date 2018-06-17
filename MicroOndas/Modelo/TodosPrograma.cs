using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Modelo
{

    class TodosPrograma
    {
        private List<Programa> p = new List<Programa>();
        private MicroOndasRepository m = new MicroOndasRepository();

        public TodosPrograma()
        {
            Programa p1 = new Programa(1, "prato", 3, '%', "Prato");
            Programa p2 = new Programa((decimal)0.3, "vegetal", 1, '*', "Vegetal");
            Programa p3 = new Programa(1, "ensopado", 2, '-', "Ensopado");
            Programa p4 = new Programa((decimal)0.4, "molho", 1, '+', "Molho");
            Programa p5 = new Programa(2, "bebida", 4, '@', "Bebida");

            p.Add(p1);
            p.Add(p2);
            p.Add(p3);
            p.Add(p4);
            p.Add(p5);
        }

        public string usePrograma(int indice, string texto)
        {
            if(texto == p[indice].Alimento)
            {
                return p[indice].AquecePrograma();
            }

            return "Alimento incorreto";
        }
    }
}
