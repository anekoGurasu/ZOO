using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO
{
    /// <summary>
    /// TŘÍDA ZOO
    /// Obsahuje data zvířat (druh, váha, pohlaví a věk zvířete)
    /// </summary>
    internal class Zvire
    {
        //privatni promenna druh (rodove a druhove jmeno zvirete)
        private string druh;
        //privatni promenna vaha (vaha zvirete)
        private int vaha;
        //privatni promenna pohlavi (pohlavi zvirete)
        private string pohlavi;
        //privatni promenna vek (vek zvirete)
        private int vek;

        /// <summary>
        /// Konstruktor Zvire
        /// </summary>
        /// <param name="druh">Rodové a druhové jméno zvířete</param>
        /// <param name="vaha">Váha zvířete</param>
        /// <param name="pohlavi">Pohlaví zvířete</param>
        /// <param name="vek">Věk zvířete</param>
        internal Zvire(string druh, int vaha, string pohlavi, int vek)
        {
            this.druh = druh;
            this.vaha = vaha;
            this.pohlavi = pohlavi;
            this.vek = vek;
        }

        /// <summary>
        /// Metoda Druh
        /// get     vrátí název druhu zvirete
        /// set     nastavi novy nazev druhu zvirete
        /// </summary>
        public string Druh 
        {  
            get { return druh; }
            set { druh = value; }
        }

        /// <summary>
        /// Metoda Vaha
        /// get     vrátí hodnotu vahy zvirete
        /// set     nastavi novou vahu zvirete
        /// </summary>
        public int Vaha
        {
            get { return vaha; }
            set { vaha = value; }
        }

        /// <summary>
        /// Metoda Vaha
        /// get     vrátí ppohlavi zvirete
        /// set     nastavi nove pohlavi zvirete
        /// </summary>
        public string Pohlavi
        {
            get { return pohlavi; }
            set { pohlavi = value; }
        }

        /// <summary>
        /// Metoda Vaha
        /// get     vrátí hodnotu veku zvirete
        /// set     nastavi novy vek zvirete
        /// </summary>
        public int Vek
        {
            get { return vek; }
            set { vek = value; }
        }
    }
}
