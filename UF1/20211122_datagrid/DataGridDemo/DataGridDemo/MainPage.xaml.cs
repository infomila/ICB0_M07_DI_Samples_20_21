using DataGridDemo.Model;
using Microsoft.Toolkit.Uwp.UI.Controls;
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
            agrupacio(1,true);
        }
        public class GroupInfoCollection<T> : ObservableCollection<T>
        {
            public object Key { get; set; }

            public new IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)base.GetEnumerator();
            }
        }
 

        private void agrupacio(int camp, Boolean asc)
        {
            // Create grouping for collection
            ObservableCollection<GroupInfoCollection<Hero>> heroes = new ObservableCollection<GroupInfoCollection<Hero>>();

            var query = from item in Hero.GetListOfHeroes()
                        orderby item.Team.Name, item.Name
                        group item by item.Team.Name into g
                        select new { GroupName = g.Key, Items = g };

            if (camp == 1)
            {
                if (asc)
                {
                    //Implement grouping through LINQ queries
                    query = from item in Hero.GetListOfHeroes()
                            orderby item.Team.Name, item.Name ascending
                            group item by item.Team.Name into g
                            select new { GroupName = g.Key, Items = g };
                }else
                {
                    query = from item in Hero.GetListOfHeroes()
                            orderby item.Team.Name, item.Name descending
                            group item by item.Team.Name into g
                            select new { GroupName = g.Key, Items = g };
                }
            } else
            {
                if (asc)
                {
                    //Implement grouping through LINQ queries
                    query = from item in Hero.GetListOfHeroes()
                            orderby item.Team.Name, item.Sex ascending
                            group item by item.Team.Name into g
                            select new { GroupName = g.Key, Items = g };
                }
                else
                {
                    query = from item in Hero.GetListOfHeroes()
                            orderby item.Team.Name, item.Sex descending
                            group item by item.Team.Name into g
                            select new { GroupName = g.Key, Items = g };
                }
            }      
       
          


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




        private void dg_loadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            Hero item = group.GroupItems[0] as Hero;
            e.RowGroupHeader.PropertyValue = item.Team.Name;
        }

        private void dtgHeroes_Sorting(object sender, DataGridColumnEventArgs e)
        {
            int camp = 0;
            if (e.Column.Tag.Equals("Name"))
            {
                camp = 1;
            }
            bool asc = (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending);
            
            agrupacio(camp,  asc);
            if (asc)
            {
                e.Column.SortDirection = DataGridSortDirection.Ascending;
            } else
            {
                e.Column.SortDirection = DataGridSortDirection.Descending;
            }

        }
    }
}
