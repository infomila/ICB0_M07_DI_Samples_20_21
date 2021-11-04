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
            DependencyProperty.Register("Valor", typeof(int), typeof(UINumericUpDown), new PropertyMetadata(0));



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



    }
}
