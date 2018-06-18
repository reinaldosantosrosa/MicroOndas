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
        private List<Programa> programas = new List<Programa>();
        private MicroOndasRepository m = new MicroOndasRepository();

        public TodosPrograma()
        {
            programas = GetDados();
        }

        public List<Programa> GetProgramas()
        {
            return programas;
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

        public void CadastraPrograma(Programa p)
        {
            var json = File.ReadAllText("Programas.json");
            var programas = JsonConvert.DeserializeObject<List<Programa>>(json);
            programas.Add(p);
            var convertedJson = JsonConvert.SerializeObject(programas, Formatting.Indented);

            File.WriteAllText("Programas.json", convertedJson);
        }

        internal void Update()
        {
            var json = File.ReadAllText("Programas.json");
            var programas = JsonConvert.DeserializeObject<List<Programa>>(json);
            this.programas = programas;
        }
    }
}
