using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Categoria
{
    internal class Vitto : ICategoria
    {
        public string Name { get; set; }


        public double Importo_RimborsatoProdotto(Servizio prodotto)
        {
            return (prodotto.Importo / 100) * 70;

        }

        public string nomeC()
        {
            return Name = "Vitto";
        }

    }
}
