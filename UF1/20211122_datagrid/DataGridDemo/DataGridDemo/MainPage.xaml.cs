using DataGridDemo.Model;
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

namespace DataGridDemo
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
            // dtgHeroes.ItemsSource = Hero.GetListOfHeroes();
            agrupacio();
        }
        public class GroupInfoCollection<T> : ObservableCollection<T>
        {
            public object Key { get; set; }

            public new IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)base.GetEnumerator();
            }
        }
        private void agrupacio()
        {
            // Create grouping for collection
            ObservableCollection<GroupInfoCollection<Hero>> heroes = new ObservableCollection<GroupInfoCollection<Hero>>();

            //Implement grouping through LINQ queries
            var query = from item in Hero.GetListOfHeroes()
                        group item by item.Team.Name into g
                        select new { GroupName = g.Key, Items = g };

            //Populate Mountains grouped collection with results of the query
            foreach (var g in query)
            {
                GroupInfoCollection<Hero> info = new GroupInfoCollection<Hero>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                heroes.Add(info);
            }
            //Create the CollectionViewSource  and set to grouped collection
            CollectionViewSource groupedItems = new CollectionViewSource();
            groupedItems.IsSourceGrouped = true;
            groupedItems.Source = heroes;
            //Set the datagrid's ItemsSource to grouped collection view source
            dtgHeroes.ItemsSource = groupedItems.View;
        }
    }
}
