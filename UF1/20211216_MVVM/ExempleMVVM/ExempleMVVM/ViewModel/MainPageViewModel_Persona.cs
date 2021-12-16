using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleMVVM.ViewModel
{
    public class MainPageViewModel_Persona : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public bool Sexe { get; set; }
        public bool Actiu { get; set; }
        public String ImageURL { get; set; }
        public String Edat { get; set; }

    }
}
