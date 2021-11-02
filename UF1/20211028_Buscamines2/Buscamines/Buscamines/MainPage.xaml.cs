using Buscamines.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Buscamines
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private int[,] tauler; 
        private int files, columnes;
        private int numMines;
        private int casellesDestapades;
        private float PERCENTATGE_MINES = 0.1f;

        public const int MINA = -1;
        public const int MIDA = 80;


        private int[,] veines = new int[,]{
                { -1 , -1},
                { -1 ,  0},
                { -1 , +1},
                { +1 , -1},
                { +1 ,  0},
                { +1 , +1},
                { +0 , +1},
                { +0 , -1},
            };

        private void initTauler()
        {

            casellesDestapades = 0;
            files = 4;
            columnes = 4;
            tauler = new int[columnes, files];
            numMines = (int)Math.Ceiling(files * columnes * PERCENTATGE_MINES);
            int minesPendents = numMines;
            while (minesPendents>0)
            {
                int indexMina = (int)((new Random()).NextDouble() * (files*columnes-1));
                int f = indexMina / columnes;
                int c = indexMina % columnes;
                // 3 files x 4 cols
                if(tauler[c,f]!=MINA)
                {
                    tauler[c, f] = MINA;
                    minesPendents--;
                    // recorregut de les veines
                    for(int i=0;i<8;i++)
                    {
                        int ff = f + veines[i,1];
                        int cc = c + veines[i,0];
                        if( 
                            between(ff,0,files) &&
                            between(cc, 0, columnes) &&
                            tauler[cc,ff]!=MINA
                         )
                        {
                            tauler[cc, ff]++;
                        }
                    }
                    //-----------------------------------
                    
                }
                
            }

        }

        private void initUI()
        {
            grdTauler.ColumnDefinitions.Clear();
            grdTauler.RowDefinitions.Clear();
            grdTauler.Children.Clear();

            // Crear una graella dinàmicament
            for (int c = 0; c < columnes; c++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(MIDA);
                grdTauler.ColumnDefinitions.Add(cd);
            }
            for (int f = 0; f < files; f++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(MIDA);
                grdTauler.RowDefinitions.Add(rd);
            }
       

            for (int f = 0; f < files; f++)
            {
                for (int c = 0; c < columnes; c++)
                {

                    UICasella casella = new UICasella();
                    casella.Valor = tauler[c, f];
                    casella.Fila = f;
                    casella.Columna = c;
                    Grid.SetColumn(casella, c);
                    Grid.SetRow(casella, f);
                    grdTauler.Children.Add(casella);
                    casella.Destapa += Casella_Destapa;
                    casella.GameOver += Casella_GameOverAsync;
                     
                }
            }
 
        }

        private async void Casella_GameOverAsync(object sender, EventArgs e)
        {
            await gameOverAsync();
        }

        private void Casella_Destapa(object sender, EventArgs e)
        {
            UICasella c = (UICasella)sender;
            destapa(c.Fila, c.Columna);
        }
         

        private void destapa(int f, int c)
        {
            int index =  (f * columnes + c) ;
            UICasella casella = (UICasella)grdTauler.Children[index];            
    
            casellesDestapades++;
            if(files*columnes-numMines==casellesDestapades)
            {
                youWinAsync();
            }
            else if (this.tauler[c, f] == 0)
            {
                // recorregut de les veines
                for (int i = 0; i < 8; i++)
                {
                    int ff = f + veines[i, 1];
                    int cc = c + veines[i, 0];
                    if (
                        between(ff, 0, files) &&
                        between(cc, 0, columnes) 
                        )
                    {
                        int indexVeina = (ff * columnes + cc);
                        UICasella casellaVeina = (UICasella)grdTauler.Children[indexVeina];
                        casellaVeina.Destapada = true;
                       
                    }
                }
            }
            
        }

        private async System.Threading.Tasks.Task youWinAsync()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Congratulations",
                Content = "You win !!!",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        private async System.Threading.Tasks.Task gameOverAsync()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Fail",
                Content = "You sucker !!!",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await dialog.ShowAsync();
            txbJeto.Text = "😢";

        }

        private bool between(int valor, int min, int max)
        {
            return valor>=min && valor<max;        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            initTauler();
            initUI();
        }

        private void txbJeto_Tapped(object sender, TappedRoutedEventArgs e)
        {
            initTauler();
            initUI();
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
