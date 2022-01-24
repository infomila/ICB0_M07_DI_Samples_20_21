using DBLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _20211125_DemoSqlite
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Dept> departaments;
        private const int DEPT_PER_PAGINA = 5;
        private int numPaginaActual = 0;
        private int numDepartaments = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            numPaginaActual = 0;
            CarregaDepartaments();
            txbNumDept.Text = DeptDB.GetNumeroDepartaments().ToString();
        }

 


        private void CarregaDepartaments()
        {
            departaments = DeptDB.GetLlistaDepartament(
                numPaginaActual,
                DEPT_PER_PAGINA,
                out numDepartaments, txtFiltreDnom.Text);
            dgrDept.ItemsSource = departaments;
            int numeroTotalPagines = GetTotalPagines();

            txbPagina.Text = (numPaginaActual+1) + "";
            btnPrevious.IsEnabled = btnFirst.IsEnabled = numPaginaActual > 0;
            btnLast.IsEnabled = btnNext.IsEnabled = numPaginaActual < numeroTotalPagines - 1;
        }

        private int GetTotalPagines()
        {
            return (int)Math.Ceiling((decimal)numDepartaments / DEPT_PER_PAGINA);
        }

        private void txtFiltreDnom_TextChanged(object sender, TextChangedEventArgs e)
        {
            numPaginaActual = 0;
            CarregaDepartaments();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Dept ds = (Dept)dgrDept.SelectedItem;
            Dept d = new Dept(ds.Dept_no, txtNom.Text, txtLoc.Text);
            DeptDB.updateDepartament(d);
            ds.Dnom = d.Dnom;
            ds.Loc = d.Loc;
    
        }

     
        private void dgrDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrDept.SelectedItem != null)
            {
                Dept d = (Dept)dgrDept.SelectedItem;
                txtLoc.Text = d.Loc;
                txtNom.Text = d.Dnom;
            }
        }

        private void btnNew_Click_1(object sender, RoutedEventArgs e)
        {
            Dept d = new Dept(0, txtNom.Text, txtLoc.Text);
            DeptDB.insert(d);
            departaments.Add(d);


            numDepartaments++;
            if (numPaginaActual == GetTotalPagines()-2 &&
                this.departaments.Count > DEPT_PER_PAGINA  )
            {
                numPaginaActual++;
                CarregaDepartaments();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Dept d = (Dept)dgrDept.SelectedItem;
            
            if(d!=null) // If.Gerard.TM
            {
                if (!DeptDB.delete(d.Dept_no))
                {
                    DisplayErrorDialog("Error", "No es pot esborrar el departament per què té empleats.");
                } else
                {
                    //departaments.Remove(d);
                    departaments.RemoveAt(dgrDept.SelectedIndex);// més eficient

                     
                    numDepartaments--;
                    if(this.departaments.Count == 0 && numPaginaActual> 0)
                    {
                        numPaginaActual--;
                        CarregaDepartaments();
                    }
                }
            }
        }


        private async void DisplayErrorDialog(
            String titol, 
            String missatge)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = titol,
                Content = missatge,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            move(0);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            move(this.numPaginaActual-1);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            move(this.numPaginaActual + 1);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            move(GetTotalPagines() -1);
        }
        /// <summary>Moves the specified number pagina.</summary>
        /// <param name="numPagina">The number pagina.</param>
        /// <example>
        ///   <code>int i=0;
        /// i++;</code>
        /// </example>
        private void move(int numPagina)
        {
            this.numPaginaActual = numPagina;
            CarregaDepartaments();
        }

    }
}
