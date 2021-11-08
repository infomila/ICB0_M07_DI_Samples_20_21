using ExamenTest.Model;
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

namespace ExamenTest
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private int indexPreguntaSeleccionada=0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mostrarPreguntaSeleccionada();
            uiPregunta.PreguntaResposta += UiPregunta_PreguntaResposta;
        }

        private void UiPregunta_PreguntaResposta(object sender, EventArgs e)
        {
            //------
            float puntuacio = 0;
            foreach(Pregunta p in Pregunta.getPreguntes())
            {
                puntuacio += p.getPuntuacio();
            }
            txbNota.Text = "" + puntuacio;
        }

        private void mostrarPreguntaSeleccionada()
        {
            uiPregunta.LaPregunta = Pregunta.getPreguntes()[indexPreguntaSeleccionada];
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            indexPreguntaSeleccionada--;
            if (indexPreguntaSeleccionada < 0) indexPreguntaSeleccionada = Pregunta.getPreguntes().Count-1;
            mostrarPreguntaSeleccionada();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            indexPreguntaSeleccionada = (indexPreguntaSeleccionada+1)% Pregunta.getPreguntes().Count;
            mostrarPreguntaSeleccionada();
        }
    }
}
