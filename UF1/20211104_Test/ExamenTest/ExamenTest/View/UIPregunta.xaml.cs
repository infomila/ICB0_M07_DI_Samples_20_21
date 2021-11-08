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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ExamenTest.View
{
    public sealed partial class UIPregunta : UserControl
    {

        public event EventHandler PreguntaResposta;


        public Pregunta LaPregunta
        {
            get { return (Pregunta)GetValue(LaPreguntaProperty); }
            set { SetValue(LaPreguntaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for La.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPreguntaProperty =
            DependencyProperty.Register("LaPregunta", typeof(Pregunta), typeof(UIPregunta),
                new PropertyMetadata(null, PreguntaChangedCallback_static));

        private static void PreguntaChangedCallback_static(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            ((UIPregunta)d).PreguntaChangedCallback(e);
        }

        private void PreguntaChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            txbEnunciat.Text = LaPregunta.Enunciat;
            stpRespostes.Children.Clear();
            int i = 0;
            foreach(string p in LaPregunta.Respostes)
            {
                RadioButton rb = new RadioButton();
                rb.Content = p;
                rb.Checked += Rb_Checked;
                rb.Tag = i;
                if(i==LaPregunta.IndexRespostaSeleccionada)
                {
                    rb.IsChecked = true;
                }
                stpRespostes.Children.Add(rb);
                i++;
            }

        }

        private void Rb_Checked(object sender, RoutedEventArgs e)
        {            
            LaPregunta.IndexRespostaSeleccionada= (int)((RadioButton)sender).Tag;// 👌👌

            // llançar l'esdeveniment "PreguntaResposta"
            PreguntaResposta?.Invoke(this, new EventArgs());
        }

        public UIPregunta()
        {
            this.InitializeComponent();
        }
    }
}
