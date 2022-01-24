using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocumentacio.Model
{
    public class Persona
    {

        private long id;
        private String NIF;
        private String nom;
        private Persona cap;


        /// <summary>
        ///   <para>
        ///     Initializes a new instance of the <see cref="Persona" /> class.
        ///     </para>
        ///     <para>
        ///     M'agrada molt documentar:
        ///     </para>
        ///     <para></para>
        ///     <list type="bullet">
        ///     <item><font color="#2a2a2a">En primer lloc per què és divertit</font></item>
        ///     <item><font color="#2a2a2a">En segon lloc per què és informatiu</font></item>
        ///     </list><para><br />
        /// </para>
        /// <para>
        /// <list type="table">
        /// <item><description>ID</description><description>NOM</description><description>COGNOM</description></item><item><description>123</description><description>12434</description><description>q2341234234</description></item>
        /// </list>
        /// </para>
        /// <para>Aquesta classe es fa servir des de la <see cref="MainPage" /></para>
        /// </summary>
        /// <example>
        ///     Exemple d'us del constructor:
        ///     <code>
        ///         Persona p = new Persona(1, "11111111H", "Paquito");
        ///         p.Nom = "Paquete";
        ///     </code>
        ///     <code source="..\Model\Persona.cs" region="exemple_constructor" />
        /// </example>
        /// 
        /// <param name="id">L'identificador de la persona</param>
        /// <param name="nIF1">El NIF de la persona</param>
        /// <param name="nom">El nom de la persona</param>
        public Persona(long id, string nIF1, string nom)
        {
            Id = id;
            NIF1 = nIF1;
            Nom = nom;
        }


        #region exemple_constructor
        private void exemple_constructor() { 
            Persona p = new Persona(1, "11111111H", "Paquito");
            p.Nom = "Paquete";
        }
        #endregion exemple_constructor

    /// <summary>
    /// # Gets the edat
    /// Aquesta funció és **la bomba** i això es _cursiva_ 
    /// </summary>
    /// <returns>l'edat de la persona.</returns> 
    public int getEdat()
        {
            return 0;
        }

        public long Id { get => id; set => id = value; }
        public string NIF1 { get => NIF; set => NIF = value; }
        /// <summary>
        /// Gets or sets the nom.
        /// </summary>
        /// <value>
        /// The nom.
        /// </value>
        public string Nom { get => nom; set => nom = value; }
        public Persona Cap { get => cap; set => cap = value; }
    }
}
