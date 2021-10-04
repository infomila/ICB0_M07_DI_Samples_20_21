using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLlistes
{
    class Persona: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private String NIF;
        private String nom;
        private DateTime dataNaixement;

        public Persona(string nIF1, string nom, DateTime dataNaixement)
        {
            NIF1 = nIF1;
            Nom = nom;
            DataNaixement = dataNaixement;
        }

        public string NIF1 { get => NIF; set { 
                NIF = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("NIF1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NomComplet"));

            }
        }
        public string Nom { get => nom; set { nom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nom"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NomComplet"));
            } }
        public DateTime DataNaixement { get => dataNaixement; set
            {
                dataNaixement = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataNaixement"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NomComplet"));
            }
        }

        public string NomComplet { get { return Nom + " - " + NIF1 + " / " + DataNaixement; } }


        public override string ToString()
        {
            return NomComplet;
        }
    }
}
