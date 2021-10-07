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

namespace DemoDiccionari
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String frase = "You think water moves fast? You should see ice.It moves like it has a mind.Like it knows it killed the world once and got a taste for murder.After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now.We said we'd say it was the snow that killed the other two, but it wasn't.Nature is lethal but it doesn't hold a candle to man. The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men.Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is the Lord when I lay My vengeance upon thee. ";
            String[] paraules = frase.Split(new char[] { ' ', ',', '.', '?', ';', ':', '!' });
            SortedDictionary<String, Int32> frequencies = new SortedDictionary<String, Int32>();
            foreach(string paraula2 in paraules)
            {
                string paraula = paraula2.ToLower();
                Int32 freq = 0;
                if (frequencies.ContainsKey(paraula))
                {
                    freq = frequencies[paraula];
                }           
                frequencies[paraula] = freq+1;               
            }
            String r = "";
            /*foreach(string paraula in frequencies.Keys)
            {
                r += paraula + ":" + frequencies[paraula]+"\n";
            }*/
            foreach(var parell in frequencies)
            {
                r += parell.Key + ":" + parell.Value + "\n";
            }
            txbOut.Text = r;

        }
    }
}
