using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace DemoLlistes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Atribut de la pàgina (tenen vida mentre la finestra està "viva")
        //List<Persona> persones = new List<Persona>();
        ObservableCollection<Persona> persones = new ObservableCollection<Persona>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            persones.Add(new Persona("11111111H", "Paco", DateTime.Now));
            persones.Add(new Persona("11111112H", "Maria", DateTime.Now));
            persones.Add(new Persona("11111113H", "Joan", DateTime.Now));
            persones.Add(new Persona("11111114H", "Pep", DateTime.Now));

            lsbPersones.ItemsSource = persones;
            lsbPersones.DisplayMemberPath = "NomComplet";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Persona nova = new Persona(txbNIF.Text, txbNovaPersona.Text, dtpDataNaix.Date.Date);
            persones.Add(nova);
            //lsbPersones.ItemsSource = null;
            //lsbPersones.ItemsSource = persones;
        }

        private void lsbPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = (Persona) lsbPersones.SelectedItem;
            //Persona p = persones[lsbPersones.SelectedIndex];
            txbNovaPersona.Text = p.Nom;
        }
    }
}
