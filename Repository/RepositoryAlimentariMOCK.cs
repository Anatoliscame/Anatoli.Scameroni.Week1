using AcademyF.Week2.Prodotti_Alim_Tecnol.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol.Repository
{
    internal class RepositoryAlimentariMOCK : IRepositoryAlim
    {

        private static List<Alimentare> alimentari = new List<Alimentare>()
        {
            new Alimentare(){ Quantita = 3, Data_scadenza =  new DateTime(2022, 04, 26), Codice = "ALIM1", Descrizione = "Torta con ciocolatto", Prezzo = 20.5},
           new Alimentare(){ Quantita = 2, Data_scadenza =  new DateTime(2022, 04, 29), Codice = "ALIM2", Descrizione = "Insalata", Prezzo = 2.5},
            new Alimentare(){ Quantita = 6, Data_scadenza =  new DateTime(2022, 05, 02), Codice = "ALIM3", Descrizione = "Banane", Prezzo = 3.5}

        };

        public List<Alimentare> GetAll() {

            return alimentari;
        }

        public string Aggiungi(Alimentare item)
        {
            if (item == null)
            {
                return "Non hai completato";
            }
            alimentari.Add(item);

            return $"Alimentare: \n{item}";
        }

    }
}
