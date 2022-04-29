using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol.Repository
{
    internal class RepositoryProdotTecnologiciMOCK
    {

        private static List<ProdottoTecnologici> tecnologici = new List<ProdottoTecnologici>() {
      
            new ProdottoTecnologici(){ Marca = "Samsung", NuovoUsato = true, Codice = "TECNO123", Descrizione = "Smartphone", Prezzo = 200.5 }
       
        };

        public List<ProdottoTecnologici> GetAll()
        {

            return tecnologici;
        }


        public string Aggiungi(ProdottoTecnologici item)
        {
            if (item == null)
            {
                return "Non hai completato";
            }
            tecnologici.Add(item);

            return $"Prodotto Tecnologico: \n{item}";
        }
    }
}
