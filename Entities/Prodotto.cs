using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol
{
    internal abstract class Prodotto
    {
        public string Codice{ get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }

        public Prodotto() { }

        public Prodotto(string codice, string descr, double prezzo)
        {
            Codice = codice;
            Descrizione = descr;
            Prezzo = prezzo;

        }
        public abstract string Disegno();
    }
}
