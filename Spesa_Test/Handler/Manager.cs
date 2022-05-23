using Spesa_Test.InterfaceFactory;
using Spesa_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Handler
{
    internal class Manager : AbstractHandler
    {
 
        public override string HandleRequest(Dipendente d)
        {

            RepositoryProdottoFile repoProd = new RepositoryProdottoFile();
            List<RepositoryProdottoFile> array_prodotti = new List<RepositoryProdottoFile>();

            var listaProdotti = repoProd.GetAll();
            double euro = d.Euro;
            
           string save = ""; int v = - 1;
            for (int i = 0; i < listaProdotti.Count; i++)
            {
    
               if ((euro > 0 && euro < 400) && (listaProdotti[i].Importo <= euro)) {
                    double resto = euro - listaProdotti[i].Importo;
                    save = save + "\n" + listaProdotti[i].Importo+$" => Resto: {resto}";
                    v = 1;
                 }
              }   
           

            if (v == 1) {
                return $"{d.FirstName} {d.LastName}  \n {save}";
            }

            return "" +base.HandleRequest(d);
        }
    }
}

