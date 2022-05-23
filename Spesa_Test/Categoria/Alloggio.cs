using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Categoria
{
    internal class Alloggio : ICategoria
    {
        public string Name { get; set; }

        public string nomeC()
        {
            return Name = "Alloggio"; 
        }

 

        public double Importo_RimborsatoProdotto(Servizio prodotto)
        {
     
            return  (prodotto.Importo / 100) * 10;

        }


/*       public double Prezzo { get; set; }

        public double Importo_Rimborsato(double prezzo)
        {
 
            double rimborso = 0;
            return rimborso = (prezzo / 100) * 100;
        }

        public string Disegno()
        {
            return $"Name:\t {Name},Importo di Rimborsato: \t {Importo_Rimborsato(Prezzo)}";
        }
*/
    }
}
