﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAApp.Model
{

    public class Rootobject
    {
        public _Internal _internal { get; set; }
        public League league { get; set; }
    }

    public class _Internal
    {
        public string pubDateTime { get; set; }
        public string igorPath { get; set; }
        public string xslt { get; set; }
        public string xsltForceRecompile { get; set; }
        public string xsltInCache { get; set; }
        public string xsltCompileTimeMillis { get; set; }
        public string xsltTransformTimeMillis { get; set; }
        public string consolidatedDomKey { get; set; }
        public string endToEndTimeMillis { get; set; }
    }

    public class League
    {
        public List<Standard> standard { get; set; }
        public List<object> africa { get; set; }
        public List<Sacramento> sacramento { get; set; }
        public List<Vega> vegas { get; set; }
        public List<Utah> utah { get; set; }
    }

    public class Standard
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temporaryDisplayName { get; set; }
        public string personId { get; set; }
        public string teamId { get; set; }
        public string jersey { get; set; }
        public bool isActive { get; set; }
        public string pos { get; set; }
        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public string heightMeters { get; set; }
        public string weightPounds { get; set; }
        public string weightKilograms { get; set; }
        public string dateOfBirthUTC { get; set; }
        public Teamsitesonly teamSitesOnly { get; set; }
        public Team[] teams { get; set; }
        public Draft draft { get; set; }
        public string nbaDebutYear { get; set; }
        public string yearsPro { get; set; }
        public string collegeName { get; set; }
        public string lastAffiliation { get; set; }
        public string country { get; set; }
        public bool isallStar { get; set; }
    }

    public class Teamsitesonly
    {
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }

    public class Draft
    {
        public string teamId { get; set; }
        public string pickNum { get; set; }
        public string roundNum { get; set; }
        public string seasonYear { get; set; }
    }

    public class Team
    {
        public string teamId { get; set; }
        public string seasonStart { get; set; }
        public string seasonEnd { get; set; }
    }

    public class Sacramento
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temporaryDisplayName { get; set; }
        public string personId { get; set; }
        public string teamId { get; set; }
        public string jersey { get; set; }
        public bool isActive { get; set; }
        public string pos { get; set; }
        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public string heightMeters { get; set; }
        public string weightPounds { get; set; }
        public string weightKilograms { get; set; }
        public string dateOfBirthUTC { get; set; }
        public Teamsitesonly1 teamSitesOnly { get; set; }
        public Team1[] teams { get; set; }
        public Draft1 draft { get; set; }
        public string nbaDebutYear { get; set; }
        public string yearsPro { get; set; }
        public string collegeName { get; set; }
        public string lastAffiliation { get; set; }
        public string country { get; set; }
    }

    public class Teamsitesonly1
    {
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }

    public class Draft1
    {
        public string teamId { get; set; }
        public string pickNum { get; set; }
        public string roundNum { get; set; }
        public string seasonYear { get; set; }
    }

    public class Team1
    {
        public string teamId { get; set; }
        public string seasonStart { get; set; }
        public string seasonEnd { get; set; }
    }

    public class Vega
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temporaryDisplayName { get; set; }
        public string personId { get; set; }
        public string teamId { get; set; }
        public string jersey { get; set; }
        public bool isActive { get; set; }
        public string pos { get; set; }
        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public string heightMeters { get; set; }
        public string weightPounds { get; set; }
        public string weightKilograms { get; set; }
        public string dateOfBirthUTC { get; set; }
        public Teamsitesonly2 teamSitesOnly { get; set; }
        public Team2[] teams { get; set; }
        public Draft2 draft { get; set; }
        public string nbaDebutYear { get; set; }
        public string yearsPro { get; set; }
        public string collegeName { get; set; }
        public string lastAffiliation { get; set; }
        public string country { get; set; }
        public bool isallStar { get; set; }
    }

    public class Teamsitesonly2
    {
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }

    public class Draft2
    {
        public string teamId { get; set; }
        public string pickNum { get; set; }
        public string roundNum { get; set; }
        public string seasonYear { get; set; }
    }

    public class Team2
    {
        public string teamId { get; set; }
        public string seasonStart { get; set; }
        public string seasonEnd { get; set; }
    }

    public class Utah
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temporaryDisplayName { get; set; }
        public string personId { get; set; }
        public string teamId { get; set; }
        public string jersey { get; set; }
        public bool isActive { get; set; }
        public string pos { get; set; }
        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public string heightMeters { get; set; }
        public string weightPounds { get; set; }
        public string weightKilograms { get; set; }
        public string dateOfBirthUTC { get; set; }
        public Teamsitesonly3 teamSitesOnly { get; set; }
        public object[] teams { get; set; }
        public Draft3 draft { get; set; }
        public string nbaDebutYear { get; set; }
        public string yearsPro { get; set; }
        public string collegeName { get; set; }
        public string lastAffiliation { get; set; }
        public string country { get; set; }
    }

    public class Teamsitesonly3
    {
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }

    public class Draft3
    {
        public string teamId { get; set; }
        public string pickNum { get; set; }
        public string roundNum { get; set; }
        public string seasonYear { get; set; }
    }

}
