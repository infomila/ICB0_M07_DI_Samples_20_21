using _20211111_UIGrafics.Model;
using System;
using System.Collections.Generic;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _20211111_UIGrafics.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ClientsPage : Page
    {
        private Client clientOriginal;
        private Client copia; 

        public ClientsPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            clientOriginal = (Client)e.Parameter;
            copia = new Client(clientOriginal.Codi, clientOriginal.Nom);
            txbName.Text = copia.Nom;
            btnSave.IsEnabled = hiHaCanvis();
        }


        private bool hiHaCanvis()
        {
            return !copia.Equals(this.clientOriginal);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            e.Cancel = hiHaCanvis();
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            copia.Nom =  txbName.Text;
            btnSave.IsEnabled = hiHaCanvis();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.clientOriginal.Nom = copia.Nom;
            this.clientOriginal.Codi = copia.Codi;
            btnSave.IsEnabled = hiHaCanvis();
        }
    }
}
