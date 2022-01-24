using ExempleMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleMVVM.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
  
        public ObservableCollection<Persona> Persones { get; set; }

        public Persona PersonaEnEdicio { get; set; }


        public MainPageViewModel()
        {
            Persones = Persona.GetPersones();
            if (Persones.Count > 0) {
                PersonaEnEdicio = Persones[0];
            }
        }


    }
}
