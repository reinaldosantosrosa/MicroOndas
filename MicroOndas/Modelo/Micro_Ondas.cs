using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace MicroOndas.Modelo
{
    class Micro_Ondas
    {
        public Micro_Ondas()
        {

        }

        
        public decimal Tempo { get; private set; }
        
        public string Alimento { get; private set; }
        
        public int Potencia { get; private set; }

        public Micro_Ondas(decimal tempo, int potencia, string alimento)
        {
            this.Tempo = tempo;
            this.Potencia = potencia;
            this.Alimento = alimento;
        }
    }
}
