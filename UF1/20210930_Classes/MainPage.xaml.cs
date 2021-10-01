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

namespace _20210930_Classes
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Cotxe c =  new Cotxe("1111KKK",234324,"Seat","Leon",DateTime.Now);
            Cotxe cc = new Cotxe("1111KKK",234324,"Seat","Leon",DateTime.Now);
            TotTerreny t = new TotTerreny("2342TTT",32646234,"Mercedes","M",DateTime.Now, 6);
            Cotxe b = t;
            TotTerreny y = (TotTerreny)b;
            txbSortida.Text += c;
            //------------------------------------
            Cotxe[] taulaDeCotxes = new Cotxe[4];
            taulaDeCotxes[0] = c;
            //-------------------------------------
            List<Cotxe> llistaDeCotxes = new List<Cotxe>();
            llistaDeCotxes.Add(c);
            llistaDeCotxes.Add(c);
            llistaDeCotxes.Add(c);
            llistaDeCotxes.Add(c);
            llistaDeCotxes.Add(c);
            llistaDeCotxes.Add(t);
            llistaDeCotxes.RemoveAt(0);
            llistaDeCotxes.Remove(c);
            txbSortida.Text += "\nQueden:" + llistaDeCotxes.Count;

            bool hiEs = llistaDeCotxes.Contains(cc);
            txbSortida.Text += "\n El cotxe hi és?" + hiEs;
        }
    }
}
