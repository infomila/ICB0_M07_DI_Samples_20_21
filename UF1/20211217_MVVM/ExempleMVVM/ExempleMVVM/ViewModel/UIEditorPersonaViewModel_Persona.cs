using ExempleMVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ExempleMVVM.ViewModel
{
    public class UIEditorPersonaViewModel_Persona : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        
        public SexeEnum Sexe { get; set; }
        public bool Actiu { get; set; }
        public String ImageURL { get; set; }
        public String Edat { get; set; }



        public String MsgErrorNom
        {
            get
            {
                if (!Persona.ValidaNom(Nom)) return "Nom incorrecte";
                else return "";
            }
        }

        public SolidColorBrush BckNom
        {
            get
            {
                if (!Persona.ValidaNom(Nom)) return new SolidColorBrush(Colors.Red);
                else return new SolidColorBrush(Colors.Transparent);
            }
        }



        public String MsgErrorEdat
        {
            get
            {
                if (!Persona.ValidaEdat(Edat)) return "Edat incorrecta";
                else return "";
            }
        }

        public SolidColorBrush BckEdat
        {
            get
            {
                if (!Persona.ValidaEdat(Edat)) return new SolidColorBrush(Colors.Red);
                else return new SolidColorBrush(Colors.Transparent);
            }
        }

        

        public Boolean SaveEnabled
        {
            get
            {
                return Persona.ValidaNom(Nom) && Persona.ValidaEdat(Edat);
            }
        }

    }
}
