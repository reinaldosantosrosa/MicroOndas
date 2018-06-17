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
        MicroOndasRepository m1 = new MicroOndasRepository();
        public Programa()
        {

        }

        public Programa(decimal Tempo, string Alimento, int Potencia, char c, string nome)
        {
            this.Tempo = Tempo;
            this.Alimento = Alimento;
            this.Potencia = Potencia;
            this.c = c;
            this.NomePrograma = nome;
        }

        public string AquecePrograma()
        {
            return m1.Aquecer(this.Tempo, this.Potencia, this.Alimento, this.c);
        }


    }

   

}
