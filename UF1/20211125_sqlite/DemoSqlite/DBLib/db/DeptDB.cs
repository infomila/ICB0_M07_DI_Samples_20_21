using DBLib.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DBLib.db
{
    public class DeptDB
    {

        public static ObservableCollection<Dept> GetLlistaDepartaments()
        {
            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

            // TACO SQL
            using(SQLiteDBContext context = new SQLiteDBContext())
            {

            }

            return departaments;
        }
    }
}
