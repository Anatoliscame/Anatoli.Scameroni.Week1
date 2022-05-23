using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Categoria
{
    internal class Viaggio : ICategoria
    {
        public string Name { get; set; } 


        public double Importo_RimborsatoProdotto(Servizio prodotto)
        {
          
            return (prodotto.Importo / 100) * 50;

        }

        public string nomeC()
        {
            return Name = "Viaggio";
        }

    }
}
