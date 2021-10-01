using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace ExempeRegExp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string FORMAT_DATA = "dd/MM/yyyy";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void txbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

            String text = txbEmail.Text;
            //Boolean emailValid = text.Contains("@") && text.Contains(".") && text.Length > 10;
 
            Regex rgx = new Regex(@"^[a-z\.\-_0-9~!#&]+@([a-z]+\.)+[a-z]{2,6}$");
            Boolean emailValid = rgx.IsMatch(text);

            btnGo.IsEnabled = emailValid;
            Color c = emailValid ? Color.FromArgb(255, 0, 255, 0) : Color.FromArgb(255, 255, 0, 0);
            txbEmail.Background = new SolidColorBrush(c);
 
        }

        private void txbNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string text = txbNumero.Text;
            //---------------------------------
            /*Boolean numeroValid = false;
            try
            {
                
                int numero = Int32.Parse(text);
                numeroValid = numero>0;
            }
            catch (Exception)
            {
                numeroValid = false;
            }*/
            //---------------------------------
            int numero;
            Boolean numeroValid = Int32.TryParse(text, out numero);
            if (numeroValid)
            {
                numeroValid = numero > 0;
            }
            //---------------------------------
            btnGoNumero.IsEnabled = numeroValid;
            Color c = numeroValid ? Color.FromArgb(255, 0, 255, 0) : Color.FromArgb(255, 255, 0, 0);
            txbNumero.Background = new SolidColorBrush(c);

        }

        private void txbSalari_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal salari;

            CultureInfo us = new CultureInfo("en-US");

            Boolean salariValid =  Decimal.TryParse(txbSalari.Text,
                NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands,
                us, out salari);
            if (salariValid)
            {
                salariValid = salari > 915;
            }
            //---------------------------------
            btnGoSalari.IsEnabled = salariValid;
            Color c = salariValid ? Color.FromArgb(255, 0, 255, 0) : Color.FromArgb(255, 255, 0, 0);
            txbSalari.Background = new SolidColorBrush(c);
            //---------------------------------------------
            if (salariValid)
            {
                
                String salariAmbFormat = salari.ToString("####,###,000.00" ,us);
                txbSalari.Text = salariAmbFormat;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime ara = DateTime.Now;
            CultureInfo ciCat = new CultureInfo("eu-ES");
            txbDiaHora.Text = ara.ToString("dd \\de MMMM \\de yyyy", ciCat);
        }

        private void txbAniversari_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime resultat;
            bool dataCorrecta = DateTime.TryParseExact(
                txbAniversari.Text, FORMAT_DATA, 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out resultat);
            if (dataCorrecta)
            {
                dtpAniversari.Date = resultat;
                cdpAniversari.Date = resultat;
            }
        }

        private void dtpAniversari_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            cdpAniversari.Date = dtpAniversari.Date;
            txbAniversari.Text = dtpAniversari.Date.ToString(FORMAT_DATA);

            /*DateTime ara = DateTime.Now;
            DateTime dema = ara.AddDays(1);
            TimeSpan off =  dema - ara;
            if (dema > ara)
            {

            }*/
        }

        private void cdpAniversari_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (cdpAniversari.Date.HasValue)
            {
                dtpAniversari.Date = cdpAniversari.Date.Value;
                txbAniversari.Text = cdpAniversari.Date.Value.ToString(FORMAT_DATA);
            }
            string nom="Maria";
            int a = 2;
            switch (nom)
            {
                case "Maria": a++;break;
                case "Pep": a--; break;
            }
        }
    }
}
