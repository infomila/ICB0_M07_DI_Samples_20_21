using ExempleMVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace ExempleMVVM.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Persona laPersonaAEditar;

        public MainPageViewModel_Persona LaPersona { get; set; } // aquesta persona té els seus camps actualitzats gràcies al Binding bidireccional

        public MainPageViewModel(Persona laPersonaAEditar)
        {
            this.laPersonaAEditar = laPersonaAEditar;
            //----------------------------------------------
            LaPersona = new MainPageViewModel_Persona();
            LaPersona.Nom = laPersonaAEditar.Nom;
            LaPersona.Sexe = laPersonaAEditar.Sexe;
            LaPersona.Edat =  laPersonaAEditar.Edat+"";
            LaPersona.Actiu = laPersonaAEditar.Actiu;
            LaPersona.ImageURL = laPersonaAEditar.ImageURL;
            //--------------------------------------------------

            LaPersona.PropertyChanged += LaPersona_PropertyChanged;

        }

        private void LaPersona_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //------------------------------------------
            Color colorNom = Colors.White;
            this.MsgErrorNom = "";
            if (!Persona.ValidaNom(LaPersona.Nom))
            {
                this.MsgErrorNom = "Nom massa curt.";
                colorNom = Colors.OrangeRed;
            }
            this.BckNom = new SolidColorBrush(colorNom);
            //------------------------------------------
            Color colorEdat = Colors.White;
            this.MsgErrorEdat = "";
            if (!Persona.ValidaEdat(LaPersona.Edat))
            {
                this.MsgErrorEdat = "Edat incorrecta.";
                colorEdat = Colors.OrangeRed;
            }
            this.BckEdat = new SolidColorBrush(colorEdat);
            //------------------------------------------

            //Persona.ValidaEdat(LaPersona.Edat);




        }

        public void Desar(object sender, RoutedEventArgs e)
        {

            //------------------------------------------
            // fer les validacions prèvies
            //------------------------------------------
            bool correcte = Persona.ValidaEdat(LaPersona.Edat);
            if(correcte) correcte = Persona.ValidaNom(LaPersona.Nom);
            if (correcte)
            {
                //------------------------------------------
                laPersonaAEditar.Nom = LaPersona.Nom;
                laPersonaAEditar.Sexe = LaPersona.Sexe;
                laPersonaAEditar.Edat =  Int32.Parse(LaPersona.Edat);
                laPersonaAEditar.Actiu = LaPersona.Actiu;
                laPersonaAEditar.ImageURL = LaPersona.ImageURL;
            }
        }
        public void Cancel(object sender, RoutedEventArgs e)
        {

        }


        public String MsgErrorNom { get; set; }

        public SolidColorBrush BckNom { get; set; }


        public String MsgErrorEdat { get; set; }

        public SolidColorBrush BckEdat { get; set; }


    }
}
