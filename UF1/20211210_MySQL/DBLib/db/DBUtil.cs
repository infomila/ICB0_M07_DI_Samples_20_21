﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DBLib.db
{
    public class DBUtil
    {
        public static void crearParametre(DbCommand consulta, string nomParametre, object value, DbType tipus )
        {
            DbParameter parametre = consulta.CreateParameter();
            parametre.ParameterName = nomParametre;
            parametre.Value = value;
            parametre.DbType = tipus;
            consulta.Parameters.Add(parametre);
        }
    }
}
