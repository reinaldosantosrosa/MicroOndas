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
            Programa p1 = new Programa(1, new List<string> { "frango", "carne" }, 3, '%', "Prato");
            Programa p2 = new Programa((decimal)0.3, new List<string> { "brocolis", "alface" }, 1, '*', "Vegetal");
            Programa p3 = new Programa(1, new List<string> { "sopa", "strogonoff" }, 2, '-', "Ensopado");
            Programa p4 = new Programa((decimal)0.4, new List<string> { "branco", "bolonhesa" }, 1, '+', "Molho");
            Programa p5 = new Programa(2, new List<string> { "café", "chá"}, 4, '@', "Bebida");

            p.Add(p1);
            p.Add(p2);
            p.Add(p3);
            p.Add(p4);
            p.Add(p5);
        }

        public string usePrograma(int indice, string texto)
        {
            if(p[indice].Alimentos.Contains(texto))
            {
                return p[indice].AquecePrograma(texto);
            }

            throw new System.ArgumentException("Alimento inválido"); 
        }
    }
}
