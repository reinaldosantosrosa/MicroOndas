using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    public interface IMicroOndasRepository
    {
        //decimal Tempo, int Potencia, string Texto, char c
        void Aquecer();
        string getTexto();

        
        
    }
}
