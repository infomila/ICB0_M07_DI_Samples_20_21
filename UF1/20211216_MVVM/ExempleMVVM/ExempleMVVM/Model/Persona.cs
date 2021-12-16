﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleMVVM.Model
{
    public class Persona : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private static ObservableCollection<Persona> _persones;
        public static ObservableCollection<Persona> GetPersones()
        {

            if(_persones==null)
            {
                _persones = new ObservableCollection<Persona>();
                _persones.Add(new Persona("Paco", true, true, "https://ep01.epimg.net/elpais/imagenes/2018/03/07/icon/1520445498_019512_1520445571_noticia_normal.jpg", 21));
                _persones.Add(new Persona("Paquita", false, true, "https://ep01.epimg.net/elpais/imagenes/2018/03/07/icon/1520445498_019512_1520445571_noticia_normal.jpg", 21));
            }
            return _persones;
        }

        //--------------------------------------------
        private String nom;
        private bool sexe;
        private bool actiu;
        private string imageURL;
        private int edat;

  

        public Persona(string nom, bool sexe, bool actiu, string imageURL, int edat)
        {
            Nom = nom;
            Sexe = sexe;
            Actiu = actiu;
            ImageURL = imageURL;
            Edat = edat;
        }

        public static bool ValidaNom(string unNom)
        {
            return unNom.Trim().Length > 3;
        }

        public static bool ValidaEdat(string edatS)
        {
            int edat;
            bool ok = int.TryParse(edatS, out edat);
            if (ok) return ValidaEdat(edat);
            else return false;
        }

        public static bool ValidaEdat( int edat)
        {
            return edat >= 1;
        }

        public string Nom { get => nom; set {
                if (!ValidaNom(value)) throw new Exception("Nom incorrecte");
                nom = value; } }
        public bool Sexe { get => sexe; set => sexe = value; }
        public bool Actiu { get => actiu; set => actiu = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public int Edat { get => edat; set
            {                
                if (!ValidaEdat(value)) throw new Exception("Edat incorrecta");
                edat = value;

            }
        }
    }
}
