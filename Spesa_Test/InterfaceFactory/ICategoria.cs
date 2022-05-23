using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceFactory
{
    internal interface ICategoria
    {
        public string Name { get; set; }

        public double Importo_RimborsatoProdotto(Servizio prodotto);

        public string nomeC();

     }
}
