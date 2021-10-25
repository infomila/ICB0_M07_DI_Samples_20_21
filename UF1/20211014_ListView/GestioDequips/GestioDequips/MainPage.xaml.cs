using GestioDequips.Model;
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

namespace GestioDequips
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<Equip> equipsFiltrats;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            List<Conferencia> c = new List<Conferencia>();
            c.Add(Conferencia.WEST);
            c.Add(Conferencia.EAST);*/
               
            cboConferencies.ItemsSource = Enum.GetValues(typeof(Conferencia)).Cast<Conferencia>().ToList();

            lsvEquips.ItemsSource = Equip.getLlistaEquips();

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            equipsFiltrats = new List<Equip>();
            foreach (Equip eq in Equip.getLlistaEquips())
            {
                bool afegirEquip = true;

                // per cada equip, validem si compleix els requisits de filtre
                // aplica el filtre de conferència (si cal)
                if (cboConferencies.SelectedItem != null)
                {
                    afegirEquip = (eq.Conf == (Conferencia)cboConferencies.SelectedItem);
                }
                //aplico el filtre de text (si cal)
                if(afegirEquip && txbLliure.Text.Trim().Length>0)
                {
                    afegirEquip =  eq.findText(txbLliure.Text);
                }
                if (afegirEquip)
                {
                    this.equipsFiltrats.Add(eq);
                }
                lsvEquips.ItemsSource = equipsFiltrats;
            }
        }
    }
}
