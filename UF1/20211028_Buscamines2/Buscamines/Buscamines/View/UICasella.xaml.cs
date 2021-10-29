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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Buscamines.View
{
    public sealed partial class UICasella : UserControl
    {

        private const int MINA = -1;

        public event EventHandler GameOver;
        public event EventHandler Destapa;

        public UICasella()
        {
            this.InitializeComponent();
        }


        #region props
        public int Fila
        {
            get { return (int)GetValue(FilesProperty); }
            set { SetValue(FilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Files.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilesProperty =
            DependencyProperty.Register("Fila", typeof(int), typeof(UICasella), new PropertyMetadata(0));



        public int Columna
        {
            get { return (int)GetValue(ColumnaProperty); }
            set { SetValue(ColumnaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Columna.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnaProperty =
            DependencyProperty.Register("Columna", typeof(int), typeof(UICasella), new PropertyMetadata(0));

        #endregion




        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(UICasella), 
                new PropertyMetadata(0, valueChangedCallbackStatic));

        private static void valueChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UICasella c = (UICasella)d;
            c.valueChangedCallback(d, e);
        }

        private void valueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // aquest mètode es llança quan Valor canvia
            //---------------------------------------------------
            if(Valor==MINA)
            {
                txbNumero.Text = "💣";
            } else if(Valor==0)
            {
                txbNumero.Text = "";
            } else
            {
                txbNumero.Text = Valor + "";
            }
        }

        public bool Marcada
        {
            get { return !txbBanderola.Text.Equals(""); }
 
        }

        // Using a DependencyProperty as the backing store for Marcada.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarcadaProperty =
            DependencyProperty.Register("Marcada", typeof(bool), typeof(UICasella), new PropertyMetadata(false));




        public bool Destapada
        {
            get { return brdTop.Visibility == Visibility.Collapsed; }
        }

        // Using a DependencyProperty as the backing store for Destapada.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DestapadaProperty =
            DependencyProperty.Register("Destapada", typeof(bool), typeof(UICasella), new PropertyMetadata(false));

        private void brdTop_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Marcada) return;

            brdTop.Visibility = Visibility.Collapsed;
            if (Valor == MINA)
            {
                GameOver?.Invoke(this, new EventArgs());
            } else
            {
                Destapa?.Invoke(this, new EventArgs());
            }
        }

        private void brdTop_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if(txbBanderola.Text.Equals(""))
            {
                txbBanderola.Text= "🚩";
            } else
            {
                txbBanderola.Text = "";
            }              
        }
    }
}
