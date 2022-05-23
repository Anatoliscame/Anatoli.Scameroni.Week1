using Spesa_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Spesa_Test.Factory
{
    internal class FactoryProdottoCattegoria
    {

        public  string importoRimborsato(string cattegoria)
        {
            int v = -1, v1 = -1, v2 = -1, v3 = -1;
            RepositoryProdottoFile repoProd = new RepositoryProdottoFile();
            List<RepositoryProdottoFile> array_prodotti = new List<RepositoryProdottoFile>();
            double rimborso = 0;
            var listaProdotti = repoProd.GetAll();
            Servizio prodotto = null;
            string save = ""; 
            for (int i = 0; i < listaProdotti.Count; i++)
            {

                if (listaProdotti[i].Categoria.Equals("Viaggio") && listaProdotti[i].Categoria.Equals(cattegoria))
                {
                    rimborso = ((listaProdotti[i].Importo / 100) * 100)+50;
                    prodotto = new Servizio(listaProdotti[i].Data_s, listaProdotti[i].Categoria, listaProdotti[i].Descrizione, rimborso);
                    save = save + "\n" + prodotto.Disegna();
                    v = 1;
                    // 400 $
              //      70%
                  //      400/100=4 4*70 =280
        
                }
                 if (listaProdotti[i].Categoria.Equals("Alloggio") &&  listaProdotti[i].Categoria.Equals(cattegoria))
                {
                    rimborso = (listaProdotti[i].Importo / 100) * 100;
                    prodotto = new Servizio(listaProdotti[i].Data_s, listaProdotti[i].Categoria, listaProdotti[i].Descrizione, rimborso);

                    save = save + "\n" + prodotto.Disegna();
                    v1 = 1;
                }
                if (listaProdotti[i].Categoria.Equals("Vitto") && listaProdotti[i].Categoria.Equals(cattegoria))
                {
                    rimborso = (listaProdotti[i].Importo / 100) * 70;
                    prodotto = new Servizio(listaProdotti[i].Data_s, listaProdotti[i].Categoria, listaProdotti[i].Descrizione, rimborso);

                    save = save + "\n" + prodotto.Disegna();
                    v2 = 1;
                }

                if (listaProdotti[i].Categoria.Equals(cattegoria)) { 

                    rimborso = (listaProdotti[i].Importo / 100) * 10;
                    prodotto = new Servizio(listaProdotti[i].Data_s, listaProdotti[i].Categoria, listaProdotti[i].Descrizione, rimborso);

                    save = save + "\n" + prodotto.Disegna();
                    v3 = 1;
                    
                }
            }

            if (v == 1 )
            {
                return "" + save;
            }
          
            if (v1 == 1)
            {
                return "" + save;
            }
            
            if (v2 == 1)
            {
                return "" + save;
            }
          
            if (v3 == 1)
            {
                return "" + save;
            }
            return "Non hai inserito la Cattegoria";
        }
    }
}
*/