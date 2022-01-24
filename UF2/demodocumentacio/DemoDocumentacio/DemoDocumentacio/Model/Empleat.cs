using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocumentacio.Model
{
    internal class Empleat:  Persona
    {
        public Empleat(long id, string nIF1, string nom):base(id, nIF1, nom)
        {
            Id = id;
            NIF1 = nIF1;
            Nom = nom;
        }
    }
}
