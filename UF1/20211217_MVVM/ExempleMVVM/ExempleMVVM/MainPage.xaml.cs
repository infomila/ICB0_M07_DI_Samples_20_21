using ExempleMVVM.Model;
using ExempleMVVM.ViewModel;
using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ExempleMVVM
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            MainPageViewModel viewModel = new MainPageViewModel();
            this.DataContext = viewModel;// MOLT IMPORTANT : permet / facilita el binding. {Binding XXXXX}
            this.ViewModel = viewModel; // també fem disponible el ViewModel via la propietat ViewModel           
        }


    }
}
