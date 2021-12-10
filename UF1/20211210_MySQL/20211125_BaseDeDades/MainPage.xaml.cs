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

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CarregaDepartaments();

            txbNumDept.Text = DeptDB.GetNumeroDepartaments().ToString();
        }

        private void CarregaDepartaments()
        {
            departaments = DeptDB.GetLlistaGepartament2();
            dgrDept.ItemsSource = departaments;
        }

        private void txtFiltreDnom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Dept> departaments = DeptDB.GetLlistaGepartament(txtFiltreDnom.Text);
            dgrDept.ItemsSource = departaments;
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
            //CarregaDepartaments();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Dept d = (Dept)dgrDept.SelectedItem;
            if(d!=null)
            {
              DeptDB.delete(d.Dept_no);
            }
        }
    }
}
