using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotify.Model
{

    //https://github.com/Fody/PropertyChanged 
    public class Persona: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private long id;
        private String nom;

        public long Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Persona(long id, string nom)
        {
            Id = id;
            Nom = nom;
        }

       /* public long Id
        {
            get => id;
            set
            {
                if (value != id)
                {
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                }

            }
        }
        public string Nom { get => nom;
            set
            {
                if (value != nom)
                {
                    nom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                }

            }
        }*/

    }
}
