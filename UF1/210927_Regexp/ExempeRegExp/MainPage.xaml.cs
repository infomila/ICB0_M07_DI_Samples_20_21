using System;
using System.Collections.Generic;

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
    }
}
