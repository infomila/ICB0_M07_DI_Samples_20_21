using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLlistes
{
    class Persona
    {
        private String NIF;
        private String nom;
        private DateTime dataNaixement;

        public Persona(string nIF1, string nom, DateTime dataNaixement)
        {
            NIF1 = nIF1;
            Nom = nom;
            DataNaixement = dataNaixement;
        }

        public string NIF1 { get => NIF; set => NIF = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DataNaixement { get => dataNaixement; set => dataNaixement = value; }

        public string NomComplet { get { return Nom + " - " + NIF1 + " / " + DataNaixement; } }

        public override string ToString()
        {
            return Nom;
        }
    }
}
