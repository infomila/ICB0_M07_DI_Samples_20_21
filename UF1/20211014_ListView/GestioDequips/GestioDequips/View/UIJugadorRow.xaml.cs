﻿using GestioDequips.Model;
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

namespace GestioDequips.View
{
    public sealed partial class UIJugadorRow : UserControl
    {
        public UIJugadorRow()
        {
            this.InitializeComponent();
        }

        //-----------------------------------------------------------
        // escriba ustd. "propdp" i tabule dos veces.



        public Jugador JugadorActual
        {
            get { return (Jugador)GetValue(JugadorActualProperty); }
            set { SetValue(JugadorActualProperty, value); }
        }


        // Using a DependencyProperty as the backing store for JugadorActual.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JugadorActualProperty =
            DependencyProperty.Register("JugadorActual", typeof(Jugador), typeof(UIJugadorRow), new PropertyMetadata(null));






    }
}
