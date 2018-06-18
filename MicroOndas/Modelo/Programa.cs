using MicroOndas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Modelo
{
    public class Programa : Micro_Ondas
    {
        
        public char C { get; set; }
        public string Instrucao {get; set;}
        public string NomePrograma { get; set; }

        //public List<string> Alimentos { get => alimentos; set => alimentos = value; }

        public List<string> Alimentos = new List<string>();

        MicroOndasRepository m1 = new MicroOndasRepository();

        public Programa()
        {

        }

        public Programa(decimal Tempo, List<string> Alimentos, int Potencia, char c, string nome)
        {
            this.Tempo = Tempo;
            this.Alimentos = Alimentos;
            this.Potencia = Potencia;
            this.C = c;
            this.NomePrograma = nome;
        }

        public Programa(decimal Tempo, List<string> Alimentos, int Potencia, char c, string nome, string instrucoes)
        {
            this.Tempo = Tempo;
            this.Alimentos = Alimentos;
            this.Potencia = Potencia;
            this.C = c;
            this.NomePrograma = nome;
            this.Instrucao = instrucoes;
        }

        public string AquecePrograma(string texto)
        {
            return m1.Aquecer(this.Tempo, this.Potencia, texto, this.C);
        }


    }

   

}
