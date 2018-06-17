using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Modelo
{
    public class Programa: Micro_Ondas
    {
        char c;
        public string NomePrograma { get; set; }
        public List<string> Alimentos { get => alimentos; set => alimentos = value; }

        private List<string> alimentos = new List<string>();
        MicroOndasRepository m1 = new MicroOndasRepository();
        public Programa()
        {

        }

        public Programa(decimal Tempo, List<string> Alimentos, int Potencia, char c, string nome)
        {
            this.Tempo = Tempo;
            this.Alimentos = Alimentos;
            this.Potencia = Potencia;
            this.c = c;
            this.NomePrograma = nome;
        }

        public string AquecePrograma(string texto)
        {
            return m1.Aquecer(this.Tempo, this.Potencia, texto, this.c);
        }


    }

   

}
