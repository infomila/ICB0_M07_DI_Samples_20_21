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

        public enum Estat
        {
          VIEW,
          MODIFICACIO,
          ALTA
        }

        // Atribut de la pàgina (tenen vida mentre la finestra està "viva")
        //List<Persona> persones = new List<Persona>();
        ObservableCollection<Persona> persones = new ObservableCollection<Persona>();
        Estat estat = Estat.VIEW;


        private void actualitzaInterficie()
        {
            btnBaixa.Visibility = (estat == Estat.VIEW) ? Visibility.Visible : Visibility.Collapsed;
            btnNou.Visibility = btnBaixa.Visibility;
            btnCancel.Visibility = estat!=Estat.VIEW ? Visibility.Visible : Visibility.Collapsed;
            btnDesar.Visibility = btnCancel.Visibility;
            lsbPersones.IsEnabled = (estat == Estat.VIEW);
            btnBaixa.IsEnabled = lsbPersones.SelectedItem != null;
        }

        private void canviEstat(Estat estatNou)
        {
            estat = estatNou;
            if (estat == Estat.VIEW)
            {
                MostraPersonaSeleccionada();
            }
            actualitzaInterficie();
        }


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

            canviEstat(Estat.VIEW);
        }
 

        private void lsbPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MostraPersonaSeleccionada();
            canviEstat(Estat.VIEW);


        }

        private void MostraPersonaSeleccionada()
        {
            if (lsbPersones.SelectedItem != null)
            {
                Persona p = (Persona)lsbPersones.SelectedItem;
                //Persona p = persones[lsbPersones.SelectedIndex];
                txbNovaPersona.Text = p.Nom;
                txbNIF.Text = p.NIF1;
                dtpDataNaix.Date = p.DataNaixement;
            }
            else
            {
                txbNovaPersona.Text = "";
                txbNIF.Text = "";
                dtpDataNaix.Date = DateTime.Now;
            }
            //canviEstat(Estat.VIEW);
        }

        private void btnBaixa_Click(object sender, RoutedEventArgs e)
        {
            if (lsbPersones.SelectedItem != null)
            {
                persones.Remove((Persona)lsbPersones.SelectedItem);
            }
        }

        private void btnNou_Click(object sender, RoutedEventArgs e)
        {
            canviEstat(Estat.ALTA);
            txbNIF.Text = "";
            txbNovaPersona.Text = "";
            dtpDataNaix.Date = DateTime.Now;
        }

        private void btnDesar_Click(object sender, RoutedEventArgs e)
        {
            if (verificaSiTotsElsCampsSonValids())
            {
                if (estat == Estat.ALTA)
                {
                    Persona nova = new Persona(txbNIF.Text, txbNovaPersona.Text, dtpDataNaix.Date.Date);
                    persones.Add(nova);
                    lsbPersones.SelectedIndex = persones.Count - 1;
                } else
                {
                    Persona paioSeleccionat = (Persona) lsbPersones.SelectedItem;
                    paioSeleccionat.NIF1 = txbNIF.Text;
                    paioSeleccionat.Nom = txbNovaPersona.Text;
                    paioSeleccionat.DataNaixement = dtpDataNaix.Date.Date;
                }
            }
            canviEstat(Estat.VIEW);
        }

        // TODO: Nyapa temporal que cal arreglar
        private bool verificaSiTotsElsCampsSonValids()
        {
            Boolean NIFValid = Persona.validaNIF(txbNIF.Text);


            Boolean NomValid = Persona.validaNom(txbNovaPersona.Text);
            txbErNom.Visibility = NomValid ? Visibility.Collapsed : Visibility.Visible;


            Boolean totValid = NIFValid && NomValid;
            btnDesar.IsEnabled = totValid;
            return totValid;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            canviEstat(Estat.VIEW);            
        }

  
        private void txbNIF_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            checkCanvis();
        }
 

        private void checkCanvis()
        {
            verificaSiTotsElsCampsSonValids();
            if (lsbPersones.SelectedItem != null)
            {
                Persona actual = (Persona)lsbPersones.SelectedItem;
                Boolean HiHaCanvis = !(
                                    actual.NIF1.Equals(txbNIF.Text) &&
                                    actual.Nom.Equals(txbNovaPersona.Text) &&
                                    actual.DataNaixement.Equals(dtpDataNaix.Date)
                                        );
                if (HiHaCanvis && estat == Estat.VIEW)
                {
                    canviEstat(Estat.MODIFICACIO);
                }
            }
        }

        private void txbNovaPersona_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            checkCanvis();
        }

        private void dtpDataNaix_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            checkCanvis();
        }

        private void dtpDataNaix_Tapped(object sender, TappedRoutedEventArgs e)
        {
            checkCanvis();
        }
    }
}
