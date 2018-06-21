using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace MicroOndas.Modelo
{
    public class Micro_Ondas
    {
        public Micro_Ondas()
        {

        }

        
        public decimal Tempo { get; set; }
        
        public string Alimento { get; set; }
        
        public int Potencia { get; set; }

        public Micro_Ondas(decimal tempo, int potencia, string alimento)
        {
            this.Tempo = tempo;
            this.Potencia = potencia;
            this.Alimento = alimento;
        }


    }
}
