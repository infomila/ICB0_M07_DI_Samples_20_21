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

namespace NumericUpDown.View
{
    public sealed partial class UINumericUpDown : UserControl
    {


        public event EventHandler ValorChanged;

        public UINumericUpDown()
        {
            this.InitializeComponent();
        }





        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(UINumericUpDown), 
                new PropertyMetadata(0, ValorChanged_static));

        private static void ValorChanged_static(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            UINumericUpDown nupd = (UINumericUpDown)d;
            nupd.PropValorChanged(e);
        }

        private void PropValorChanged(DependencyPropertyChangedEventArgs e)
        {
            // això es dispara quan Valor canvia
            if(Valor>Max || Valor<Min)
            {
                Valor = (int)e.OldValue;
            }
            ValorChanged?.Invoke(this, new EventArgs());
            txbNumero.Text = "" + Valor;
        }

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(UINumericUpDown), new PropertyMetadata(Int32.MaxValue));



        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(UINumericUpDown), new PropertyMetadata(Int32.MinValue));



        public int Step
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Step.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(UINumericUpDown), new PropertyMetadata(1));

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            //txbNumero.Text = ""+ Int32.Parse(txbNumero.Text) + this.Step;
            this.Valor += this.Step;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            this.Valor -= this.Step;
        }

        private void txbNumero_BeforeTextChanging(TextBox sender, 
            TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => (!char.IsDigit(c) && c!='-' ));
        }

        private void txbNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numero;
            bool esNumero = Int32.TryParse( txbNumero.Text, out numero) ;
            if (esNumero)
            {
                Valor = numero;
            } else
            {
                Valor = Min;
                txbNumero.Text = ""+Valor;
            }
        }
    }
}
