
using Spesa_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceFactory
{
    internal interface IGestioneProdotti : IRepository<Servizio>
    {
        //List<Prodotto> GetProdottiConScadenzaOggi();
        public abstract List<Servizio> GetAll();



        public abstract bool Aggiungi(Servizio item);
      //  public abstract T GetByCodice(string codice);

    }
}
