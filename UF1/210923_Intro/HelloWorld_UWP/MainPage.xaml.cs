using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

namespace HelloWorld_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //===============================
        // Atributs
        //===============================
        int i = 0;
        int j;
        //===============================

        public MainPage()
        {
            this.InitializeComponent();
            i++;
            j++;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            String text = txtMissatge.Text;
            text = text.Trim();

            //String sortida = MetodeTradicional(text);
            //String sortida = MetodeString(text);
            String sortida = MetodeSplit(text);
            txtSortida.Text = sortida;



            /*
            // això s'executarà quan algú faci click al botó
            txtMissatge.Text = "KK";
            int i = 0;
            Debug.WriteLine("Sóc un missatge de debug");
            i++;
            this.i++;
            long numeroLong = 123L;
            i = (int) numeroLong; // cast forçós

            bool esCert = true;
            esCert = i < 5;

            char lletra = 'a';

            float numero = 123.12f;
            double numeroDoble = 123.234;

            float quantitat = 25.34f;

            // CTRL+K+  C / U
            decimal preu = 25.24m;


            const double PI = 3.14159;


            int k=0;
            k++;

             
            for (int n = 0; n < 1000; n++)
            {

            }

            //------------------------------------------

            string nom = "Paco";
            string cognom = "Gómez";
            string nomComplet = nom + " " + cognom;
            nomComplet = nomComplet.ToUpper();
            txtMissatge.Text = nomComplet;

            //---------------------------------
            // muntar una cadena que contingui tots els 
            // nombres del 1 al 100.000.000
            // 
            string sortida = "";
            StringBuilder sb = new StringBuilder();
            
            for(int kk = 0; kk < 10000000; kk++)
            {
                //sortida = sortida  + kk + ",";
                //sortida += (kk + ",");
                sb.Append(kk + ",");
            }
            //txtMissatge.Text = sortida;
            txtMissatge.Text = sb.ToString().Substring(0, 1000);
            string a = "Cadena";
            a.IndexOf()*/

        }

        private string MetodeSplit(string text)
        {
            string[] paraules = text.Split(new char[] {' ',',',';', ':' },StringSplitOptions.RemoveEmptyEntries);
            string ret = ""; 
            foreach(string p in paraules){
                ret += p + "\n";
            }
            return ret;
        }

        private string MetodeTradicional(string text)
        {
            string sortida = "";

            bool anteriorEsSeparador = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (!esSeparador(text[i]))
                {
                    sortida += text[i];
                    anteriorEsSeparador = false;
                }
                else
                {
                    if (i > 0 && !anteriorEsSeparador)
                    {
                        sortida += '\n';
                    }
                    anteriorEsSeparador = true;
                }
            }

            return sortida;
        }




        private string MetodeString(string text)
        {
            string sortida = "";
            char[] separadors = { ' ', ';', '.', ',' };
            //         0123456789012
            // text = "HOLA ,BON DIA"
            // ",BON DIA"
            // "BON DIA "
        
            while (text.Length > 0)
            {
                int indexSeparador = text.IndexOfAny(separadors);
                String paraula = text.Substring(0, indexSeparador );
                if (paraula.Length > 0)
                {
                    sortida += (paraula + "\n");
                }
                if (indexSeparador == text.Length - 1) break;

                text = text.Substring(indexSeparador + 1, text.Length - indexSeparador - 1);
            }
            return sortida;
        }



        private bool esSeparador(char v)
        {
            //char[] separadors = { ' ', ';', '.', ',' };
            string separadors = " ;,.";
            return separadors.IndexOf(v) >= 0;
        }
    }
}
