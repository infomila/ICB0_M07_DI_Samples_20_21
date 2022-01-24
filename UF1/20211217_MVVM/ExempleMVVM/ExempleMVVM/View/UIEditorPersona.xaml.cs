using ExempleMVVM.Model;
using ExempleMVVM.ViewModel;
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

namespace ExempleMVVM.View
{
    public sealed partial class EditorPersona : UserControl
    {
      
        public UIEditorPersonaViewModel ViewModel { get; set; }

        public EditorPersona()
        {
            this.InitializeComponent();
        }



        public Persona LaPersonaEnEdicio
        {
            get { return (Persona)GetValue(LaPersonaProperty); }
            set { SetValue(LaPersonaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LaPersona.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPersonaProperty =
            DependencyProperty.Register("LaPersonaEnEdicio", typeof(Persona), typeof(EditorPersona), 
                new PropertyMetadata(null, LaPersonaChangedCallback));

        private static void LaPersonaChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EditorPersona ed = (EditorPersona)d;
            ed.LaPersonaChangedCallback_Static(d,e);
        }
        private void LaPersonaChangedCallback_Static(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {            
            if (e.NewValue != null)
            {
                UIEditorPersonaViewModel viewModel =  new UIEditorPersonaViewModel(LaPersonaEnEdicio);
                this.DataContext = viewModel;// MOLT IMPORTANT : permet / facilita el binding. {Binding XXXXX}
                this.ViewModel = viewModel; // també fem disponible el ViewModel via la propietat ViewModel
            }
        }
    }
}
