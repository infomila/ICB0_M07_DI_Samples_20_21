using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20211111_UIGrafics.Model
{
    public class Client
    {
        private int codi;
        private string nom;

        public Client(int codi, string nom)
        {
            Codi = codi;
            Nom = nom;
        }

        public int Codi { get => codi; set => codi = value; }
        public string Nom { get => nom; set => nom = value; }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   Codi == client.Codi &&
                   Nom == client.Nom;
        }

        public override int GetHashCode()
        {
            var hashCode = 1331389189;
            hashCode = hashCode * -1521134295 + Codi.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            return hashCode;
        }
    }
}
