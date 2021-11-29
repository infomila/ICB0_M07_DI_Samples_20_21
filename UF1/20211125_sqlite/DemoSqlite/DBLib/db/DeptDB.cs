using DBLib.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace DBLib.db
{
    public class DeptDB
    {


        public static int GetNumeroDepartaments()
        {
            // - - - - - - - - - - - Cortar aquí - - - - - - - - - -

            using (var context = new SQLiteDBContext()) // inicialitza un context
            {
                using (var connection = context.Database.GetDbConnection()) // pren la connexió de la BD
                {
                    connection.Open();
                    using (var consulta = connection.CreateCommand())
                    {
                        consulta.CommandText = @"select count(1) as boniato
                                                 from dept";
                        return (int)(long) consulta.ExecuteScalar();
                         
                    }
                }
            }            
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  -
        }

        public static ObservableCollection<Dept> GetLlistaDepartaments(String nomDept)
        {
            // - - - - - - - - - - - Cortar aquí - - - - - - - - - -
            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

            using (var context = new SQLiteDBContext()) // inicialitza un context
            {
                using (var connection = context.Database.GetDbConnection()) // pren la connexió de la BD
                {
                    connection.Open();
                    using (var consulta = connection.CreateCommand())
                    {
                        DBUtil.crearParametre(consulta, "@param_dnom", "%"+nomDept+"%", System.Data.DbType.String);

                        consulta.CommandText = $@"select dept_no,dnom,loc  
                                                 from dept where upper(dnom) like upper(@param_dnom)";
                        DbDataReader reader = consulta.ExecuteReader();
                        Dictionary<string, int> ordinals = new Dictionary<string, int>();

                        string[] cols = { "DEPT_NO", "DNOM", "LOC" };
                        foreach (string c in cols)
                        {
                            ordinals[c] = reader.GetOrdinal(c);
                        }

                        while (reader.Read())
                        {
                            int dept_no = reader.GetInt32(ordinals["DEPT_NO"]);
                            string dnom = reader.GetString(ordinals["DNOM"]);
                            string loc = reader.GetString(ordinals["LOC"]);

                            Dept d = new Dept(dept_no, dnom, loc);
                            departaments.Add(d);
                        }
                    }
                }
            }

            return departaments;
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  -

        }

        public static ObservableCollection<Dept> GetLlistaDepartaments()
        {
            // - - - - - - - - - - - Cortar aquí - - - - - - - - - -
            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

            using (var context = new SQLiteDBContext()) // inicialitza un context
            {
                using (var connection = context.Database.GetDbConnection()) // pren la connexió de la BD
                {
                    connection.Open();
                    using (var consulta = connection.CreateCommand())
                    {
                        consulta.CommandText = @"select dept_no,dnom,loc  
                                                 from dept";
                        DbDataReader reader = consulta.ExecuteReader();
                        Dictionary<string, int> ordinals = new Dictionary<string, int>();

                        string[] cols = { "DEPT_NO", "DNOM", "LOC" };
                        foreach (string c in cols)
                        {
                            ordinals[c] = reader.GetOrdinal(c);
                        }

                        while (reader.Read())
                        {
                            int dept_no = reader.GetInt32(ordinals["DEPT_NO"]);
                            string dnom = reader.GetString(ordinals["DNOM"]);
                            string loc = reader.GetString(ordinals["LOC"]);

                            Dept d = new Dept(dept_no, dnom, loc);
                            departaments.Add(d);
                        }
                    }
                }
            }

            return departaments;
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  -

        }
    }
}
