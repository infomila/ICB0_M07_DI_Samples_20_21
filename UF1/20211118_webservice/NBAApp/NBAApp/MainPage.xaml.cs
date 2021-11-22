using NBAApp.Model;
using NBAApp.ServiceWeather;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace NBAApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //https://data.nba.net/prod/v1/2021/players/203500_profile.json
        async void getPlayers()
        {
            /*
            double pi = await calculaNumeroPi();
            txbTotal.Text = pi+"";
            string url = "https://data.nba.net/prod/v1/2021/players.json";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url); // l'execució del mètode és assíncrona, i es fa en un fil.
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(response);
                        lsvJugadors.ItemsSource = data.league.standard;
            */
            Task<double> tascaPi = calculaNumeroPi();
            
            string url = "https://data.nba.net/prod/v1/2021/players.json";
            HttpClient client = new HttpClient();
            Task<String> tascaJSONDownload = client.GetStringAsync(url); // l'execució del mètode és assíncrona, i es fa en un fil.

            await Task.WhenAll( tascaPi, tascaJSONDownload);
            // Task.WaitAll --> NO USAR....bloqueja el fil d'interfície gràfica

            double pi = tascaPi.Result;
            string response = tascaJSONDownload.Result;

            txbTotal.Text = pi + "";

            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(response);
            lsvJugadors.ItemsSource = data.league.standard;

        }

        private async Task<double> calculaNumeroPi()
        {
            await Task.Delay(6000);

            return 3.14159;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            getPlayers();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            btnGo.Background = new SolidColorBrush(Colors.Lime);
        }

        public void weather()
        {
  
        }
    }
}
