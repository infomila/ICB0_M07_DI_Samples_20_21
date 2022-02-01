using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocumentacio.Model
{
    class Factura
    {
        private Persona propietari;
        public Factura()
        {
            Persona p = new Persona(1, "11111111H", "Paquito");
        }

        public Persona Propietari { get => propietari; set => propietari = value; }
    }
}
