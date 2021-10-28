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
            /*
            <Border Grid.Row="0" Grid.Column="1" BorderBrush="Black" BorderThickness="1" Background="#cccccc" Width="80" Height="80">
                <TextBlock Text="3" FontSize="60" TextAlignment="Center" 
                VerticalAlignment="Center" Foreground="red">3</TextBlock>
            </Border>
             */

            for (int f = 0; f < files; f++)
            {
                for (int c = 0; c < columnes; c++)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0,0,0));
                    border.BorderThickness = new Thickness(1);
                    border.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                    TextBlock tb = new TextBlock();
                    tb.FontSize = 60;
                    tb.TextAlignment = TextAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.Foreground = new SolidColorBrush(Colors.Red);
                    String textCasella = "";
                    switch (tauler[c, f])
                    {
                        case MINA: textCasella = "💣"; break;
                        case 0: textCasella = ""; break;
                        default: textCasella = tauler[c, f] + ""; break;
                    }
                    tb.Text = textCasella;


                    Border botoTap = new Border();
                    botoTap.HorizontalAlignment = HorizontalAlignment.Stretch;
                    botoTap.VerticalAlignment = VerticalAlignment.Stretch;
                    botoTap.Background = new SolidColorBrush(Colors.LightGray);
                    botoTap.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    botoTap.BorderThickness = new Thickness(1);
                    botoTap.Tag = false;
                    botoTap.Tapped += BotoTap_Tapped;
                    botoTap.RightTapped += BotoTap_RightTapped;

                    TextBlock banderola = new TextBlock();
                    banderola.FontSize = 60;
                    banderola.TextAlignment = TextAlignment.Center;
                    banderola.VerticalAlignment = VerticalAlignment.Center;
                    banderola.Foreground = new SolidColorBrush(Colors.Black);
                    banderola.Text = "";
                    botoTap.Child = banderola;


                    /*Image im = new Image();
                    im.Source = new BitmapImage( new Uri(this.BaseUri, "Assets/quad.png" ));
                    botoTap.Child = im;*/

                     Grid.SetColumn(botoTap, c);
                    Grid.SetRow(botoTap, f);

                    border.Child = tb;
                    Grid.SetColumn(border, c);
                    Grid.SetRow(border, f);
                    grdTauler.Children.Add(border);
                    grdTauler.Children.Add(botoTap);
                }
            }
 
        }

        private void BotoTap_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Border b = (Border)sender;
            TextBlock tb = (TextBlock) b.Child;
            Boolean teBanderola = (bool)b.Tag;
            if (teBanderola)
            {
                tb.Text = "";
            } else
            {
                tb.Text = "🚩";
            }
            b.Tag = !teBanderola;
        }

        private void BotoTap_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border b = (Border)sender;
            int c = Grid.GetColumn(b);
            int f = Grid.GetRow(b);

      
            TextBlock tb = (TextBlock)b.Child;
            Boolean teBanderola = (bool)b.Tag;
            if (!teBanderola)
            {
                destapa(f, c);
            }
            
        }


        private void destapa(int f, int c)
        {
            int index = 2 * (f * columnes + c) + 1;
            Border t = (Border)grdTauler.Children[index];
            
            //tallem la recursivitat evitant que es destapin coses
            // que estan destapades.
            if (t.Visibility == Visibility.Collapsed) return;

            

            if (this.tauler[c,f]==MINA)
            {
               gameOverAsync();
            } else  // número o buida
            {
                t.Visibility = Visibility.Collapsed;
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
                            destapa(ff, cc);                         
                        }
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
