using Spesa_Test.Handler;
using Spesa_Test.InterfaceFactory;
using Spesa_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test
{
    internal class Nessuna_SpesaApprovata : AbstractHandler
    {

        public override string HandleRequest(Dipendente d)
        {

            RepositoryProdottoFile repoProd = new RepositoryProdottoFile();
            List<RepositoryProdottoFile> array_prodotti = new List<RepositoryProdottoFile>();

            var listaProdotti = repoProd.GetAll();
            double euro = d.Euro;

            string save = ""; int v = -1;
            for (int i = 0; i < listaProdotti.Count; i++)
            {

                if ((euro > 2500) && (listaProdotti[i].Importo > 2500))
                {

                    save = save + "\n" + listaProdotti[i].Importo;
                    v = 1;
                }
            }

            if (v == 1)
            {
                return $"{d.FirstName} {d.LastName}: \n Nessuna spesa sopra i 2500 e' approvata \n {save}";
            }

            return "" + base.HandleRequest(d );
        }

    }
}
