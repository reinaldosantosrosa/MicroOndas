using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;

namespace MicroOndas.Modelo
{

    class TodosPrograma
    {
        private List<Programa> p = new List<Programa>();
        List<Programa> programas = new List<Programa>();
        private MicroOndasRepository m = new MicroOndasRepository();

        public TodosPrograma()
        {
            Programa p1 = new Programa(1, new List<string> { "frango", "carne" }, 3, '%', "Prato");
            p1.Instrucao = "Aquece os alimentos frango e carne";
            Programa p2 = new Programa((decimal)0.3, new List<string> { "brocolis", "alface" }, 1, '*', "Vegetal");
            p2.Instrucao = "Aquece os alimentos brocolis e alface";
            Programa p3 = new Programa(1, new List<string> { "sopa", "strogonoff" }, 2, '-', "Ensopado");
            p3.Instrucao = "Aquece os alimentos sopa e strogonoff";
            Programa p4 = new Programa((decimal)0.4, new List<string> { "branco", "bolonhesa" }, 1, '+', "Molho");
            p4.Instrucao = "Aquece os molhos branco e bolonhesa";
            Programa p5 = new Programa(2, new List<string> { "café", "chá"}, 4, '@', "Bebida");
            p5.Instrucao = "Aquece as bebidas café e chá";

            programas = GetDados();

            p.Add(p1);
            p.Add(p2);
            p.Add(p3);
            p.Add(p4);
            p.Add(p5);
        }

        public string UsePrograma(int indice, string texto)
        {
            if(programas[indice].Alimentos.Contains(texto))
            {
                return programas[indice].AquecePrograma(texto);
            }

            throw new System.ArgumentException("Alimento inválido"); 
        }

        public Programa ShowPrograma(int indice)
        {
            return programas[indice];
        }

        public Programa PesquisaAlimento(string text)
        {
            foreach (var i in programas)
            {
                if (i.Alimentos.Contains(text))
                {
                    return i;
                }
            }
            return null;
        }

        private static List<Programa> GetDados()
        {
            var json = File.ReadAllText("Programas.json");
            var programas = JsonConvert.DeserializeObject<List<Programa>>(json);
            return programas;
        }
    }
}
