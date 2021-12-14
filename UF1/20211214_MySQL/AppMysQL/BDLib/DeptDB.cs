using BDLib.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Text;

namespace BDLib
{
    public class DeptDB
    {
        public static int GetNumeroDepartaments()
        {
            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        consulta.CommandText = @"select count(1)
                                                from dept";

                        return (int)((long) consulta.ExecuteScalar()); //per cuan pot retorna una i nomes una fila

                    }
                }
            }
        }

        private delegate T callable_query<T>(DbCommand consulta);


        private static T launchQuery<T>(callable_query<T> cq)
        {
            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        return cq(consulta);
                    }
                }
            }
        }


        public static ObservableCollection<Dept> GetLlistaGepartament2()
        {
            return launchQuery<ObservableCollection<Dept>>(
                 delegate (DbCommand consulta)
                 {

                     ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

                     consulta.CommandText = @"select dept_no, dnom, loc
                                                from dept";

                     DbDataReader reader = consulta.ExecuteReader(); //per cuan pot retorna mes d'una fila

                     Dictionary<string, int> ordinals = new Dictionary<string, int>();
                     string[] cols = { "DEPT_NO", "DNOM", "LOC" };
                     foreach (string c in cols)
                     {
                         ordinals[c] = reader.GetOrdinal(c);
                     }


                     while (reader.Read()) //llegeix la fila seguent, retorna true si ha pogut llegir la fila, retorna false si no hi ha mes dades per lleguir
                     {
                         int dept_no = reader.GetInt32(ordinals["DEPT_NO"]);
                         string dnom = reader.GetString(ordinals["DNOM"]);
                         string loc = reader.GetString(ordinals["LOC"]);

                         Dept d = new Dept(dept_no, dnom, loc);
                         departaments.Add(d);
                     }

                     return departaments;
                 });
        }

        public static bool delete(int dept_no)
        {
            bool haAnatBe = true;
            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    DbTransaction transaccio = connection.BeginTransaction(); //Creacio d'una transaccio

                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        consulta.Transaction = transaccio; // marques la consulta dins de la transacció


                        DBUtil.crearParametre(consulta, "@DEPT_NO", dept_no, DbType.Int32);
                        consulta.CommandText = "select count(1) from emp where dept_no = @DEPT_NO ";                       
                        long numEmpleats = (long)consulta.ExecuteScalar();

                        if (numEmpleats > 0) return false;

                        consulta.CommandText = "delete from dept where dept_no = @DEPT_NO ";

                        int numDeleted = consulta.ExecuteNonQuery();
                        if(numDeleted!=1)
                        {
                            transaccio.Rollback();
                            haAnatBe = false;
                        }
                        transaccio.Commit();      
                        return haAnatBe;
                    }
                }

            }
        }

        public static void insert(Dept d)
        {
            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    DbTransaction transaccio = connection.BeginTransaction(); //Creacio d'una transaccio

                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        consulta.Transaction = transaccio; // marques la consulta dins de la transacció


                        DBUtil.crearParametre(consulta, "@TABLE_NAME", "dept", DbType.String);
                        consulta.CommandText = "select last_id+1 from ids where table_name = @TABLE_NAME for update";
                        decimal nextId = (decimal)consulta.ExecuteScalar();
                        consulta.CommandText = "update ids set last_id=last_id+1 where table_name = @TABLE_NAME";
                        int actualitzades = consulta.ExecuteNonQuery();
                        if(actualitzades!=1)
                        {
                            transaccio.Rollback();
                            throw new Exception("A la platja exception!");
                        }

                        DBUtil.crearParametre(consulta, "@DNOM", d.Dnom, DbType.String);
                        DBUtil.crearParametre(consulta, "@LOC", d.Loc, DbType.String);
                        DBUtil.crearParametre(consulta, "@DEPT_NO", nextId, DbType.Int32);

                        consulta.CommandText = "insert into dept (dept_no, dnom, loc) values ( @DEPT_NO, @DNOM, @LOC )";


                        int numeroDeFiles = consulta.ExecuteNonQuery(); //per fer un update o un delete
                        if (numeroDeFiles != 1)
                        {
                            //shit happens
                            transaccio.Rollback();
                        }
                        else
                        {
                            d.Dept_no = (int)nextId;
                            transaccio.Commit();
                        }

                    }
                
            }

        }

    }

    public static ObservableCollection<Dept> GetLlistaDepartament()
        {
            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

            using(MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using(DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        consulta.CommandText = @"select dept_no, dnom, loc
                                                from dept";

                        DbDataReader reader = consulta.ExecuteReader(); //per cuan pot retorna mes d'una fila

                        Dictionary<string, int> ordinals = new Dictionary<string, int>();
                        string[] cols = {"DEPT_NO", "DNOM", "LOC" };
                        foreach (string c in cols)
                        {
                            ordinals[c] = reader.GetOrdinal(c);
                        }


                        while (reader.Read()) //llegeix la fila seguent, retorna true si ha pogut llegir la fila, retorna false si no hi ha mes dades per lleguir
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
        }

        public static ObservableCollection<Dept> GetLlistaDepartament( 
                            int numPagina,int midaPagina,
                            out int numeroDepartaments,  
                            String nomDept)
        {
            ObservableCollection<Dept> departaments = new ObservableCollection<Dept>();

            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        
                        DBUtil.crearParametre(consulta, "@param_dnom",  nomDept , DbType.String);
                        DBUtil.crearParametre(consulta, "@param_dnom_like", "%" + nomDept + "%", DbType.String);

                        consulta.CommandText = $@"select count(*)
                                                from dept
                                                where 
                                        (@param_dnom='' OR upper(dnom) like upper(@param_dnom_like) )";
                        numeroDepartaments =   (int)((long)consulta.ExecuteScalar());

                        consulta.CommandText = $@"select dept_no, dnom, loc
                                                from dept
                                                where 
                                               (@param_dnom='' OR upper(dnom) like upper(@param_dnom_like) )
                                               limit {numPagina*midaPagina}, {midaPagina}";

                        DbDataReader reader = consulta.ExecuteReader(); //per cuan pot retorna mes d'una fila

                        Dictionary<string, int> ordinals = new Dictionary<string, int>();
                        string[] cols = { "DEPT_NO", "DNOM", "LOC" };
                        foreach (string c in cols)
                        {
                            ordinals[c] = reader.GetOrdinal(c);
                        }


                        while (reader.Read()) //llegeix la fila seguent, retorna true si ha pogut llegir la fila, retorna false si no hi ha mes dades per lleguir
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
        }

        public static void updateDepartament(Dept d)
        {
            using (MyDBContext context = new MyDBContext()) //crea el contexte de la base de dades
            {
                using (DbConnection connection = context.Database.GetDbConnection()) //pren la conexxio de la BD
                {
                    connection.Open();
                    DbTransaction transaccio = connection.BeginTransaction(); //Creacio d'una transaccio

                    using (DbCommand consulta = connection.CreateCommand())
                    {
                        consulta.Transaction = transaccio; // marques la consulta dins de la transacció

                        DBUtil.crearParametre(consulta, "@DNOM",    d.Dnom , DbType.String);
                        DBUtil.crearParametre(consulta, "@LOC",     d.Loc, DbType.String);
                        DBUtil.crearParametre(consulta, "@DEPT_NO", d.Dept_no, DbType.Int32);

                        consulta.CommandText = $@"update dept set DNOM=@DNOM, LOC=@LOC where DEPT_NO=@DEPT_NO";

                        int numeroDeFiles = consulta.ExecuteNonQuery(); //per fer un update o un delete
                        if(numeroDeFiles!=1)
                        {
                            //shit happens
                            transaccio.Rollback();
                        } else
                        {
                            transaccio.Commit();
                        }

                    }
                }
            }

        }



    }



}
