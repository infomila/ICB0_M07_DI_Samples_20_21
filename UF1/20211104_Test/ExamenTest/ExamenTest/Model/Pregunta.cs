using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.Model
{
    public class Pregunta
    {
        private const int NO_CONTESTADA = -1;
        private float valor;
        private String enunciat;
        private ObservableCollection<String> respostes;
        private int indexRespostaCorrecta;
        
        //-----------------------------------

        
            
            
        //-----------------------------------
        private int indexRespostaSeleccionada = NO_CONTESTADA;

        public Pregunta(float valor, string enunciat, ObservableCollection<string> respostes, int indexRespostaCorrecta)
        {
            Valor = valor;
            Enunciat = enunciat;
            Respostes = respostes;
            IndexRespostaCorrecta = indexRespostaCorrecta;
        }

        #region propietats
        public float Valor { get => valor; set => valor = value; }
        public string Enunciat { get => enunciat; set => enunciat = value; }
        public ObservableCollection<string> Respostes {
            get => respostes;
            set { if (value.Count < 2) throw new Exception("falten respostes");
                respostes = value; } }
        public int IndexRespostaCorrecta { get => indexRespostaCorrecta;
            set
            {
                if(respostes==null || 
                    respostes.Count-1< value ||
                    value<0)
                    throw new Exception("Índex incorrecte");
                indexRespostaCorrecta = value;
            }
        }

        public int IndexRespostaSeleccionada { get => indexRespostaSeleccionada; set => indexRespostaSeleccionada = value; }
        #endregion


        public float getPuntuacio()
        {
            if(IndexRespostaSeleccionada==NO_CONTESTADA)
            {
                return 0;
            } else if (IndexRespostaSeleccionada == IndexRespostaCorrecta)
            {
                return Valor;
            }
            else
            {
                return -(Valor / (Respostes.Count-1));
            }
        }

        //----------------------------------------
        // secció d'estàtics
        private static ObservableCollection<Pregunta> _preguntes;

        public static ObservableCollection<Pregunta> getPreguntes()
        {
            if(_preguntes==null)
            {
                _preguntes = new ObservableCollection<Pregunta>();

                //ObservableCollection < String > r = 

                Pregunta p1 = new Pregunta(1, "De quin color és el sol?",
                    new ObservableCollection<String>(new string[] { "Blanc", "Negre", "Groc", "Blau" }), 2 );
                Pregunta p2 = new Pregunta(1, "De quin color és la lluna?",
                    new ObservableCollection<String>(new string[] { "Blanc", "Negre", "Groc", "Blau" }), 0);
                Pregunta p3 = new Pregunta(1, "Que costa aprovar DI?",
                    new ObservableCollection<String>(new string[] { "JJJJJ", "100000000", "BigDecimal", "Seychelles" , "Totes les anteriors"}), 4);
                _preguntes.Add(p1);
                _preguntes.Add(p2);
                _preguntes.Add(p3);
            }
            return _preguntes;
        }
        
    }
}
