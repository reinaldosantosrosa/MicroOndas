using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    public interface IMicroOndasRepository
    {
       // void Liga();
        string Aquecer(decimal Tempo, int Potencia, string Texto, char c);
       // string Programa(string Programa, int Tempo, int Potencia, string Texto);
        
    }
}
