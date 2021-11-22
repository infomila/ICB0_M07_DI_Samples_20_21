using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace WebService
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

        async void getTemperature()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather/?q=Barcelona&APPID=853dbcea2a5b4eb495d21a3cef29d1af";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<Rootobject>(response);
            temperature.Text = data.main.temp.ToString() + " 'F";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            getTemperature();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            double d = await longCalculationAsync();
            temperature.Text = "" + d;
        }

        private async System.Threading.Tasks.Task<double> longCalculationAsync()
        {
            await Task.Delay(3000);
            return 3.14159;
        }
    }
}
