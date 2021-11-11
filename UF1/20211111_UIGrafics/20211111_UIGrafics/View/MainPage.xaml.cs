using _20211111_UIGrafics.Model;
using _20211111_UIGrafics.View;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _20211111_UIGrafics
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Client elClient;

        public MainPage()
        {
            this.InitializeComponent();
            elClient = new Client(0,"<default>");
        }

        private void NavigationView_ItemInvoked(NavigationView sender, 
            NavigationViewItemInvokedEventArgs args)
        {
            if(nviClient.Content.Equals( args.InvokedItem))
            {
                frmPrincipal.Navigate(typeof(ClientsPage), elClient);
            } else
            {
                frmPrincipal.Navigate(typeof(FacturesPage));
            }            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(typeof(ClientsPage), elClient);
        }
    }
}
