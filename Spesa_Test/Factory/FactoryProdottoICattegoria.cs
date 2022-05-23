using Spesa_Test.Categoria;
using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Factory
{
    internal class FactoryProdottoICattegoria
    {
        public ICategoria importoRimborsatoICattegoria(string NomeCattegoria) {
 

        ICategoria scelta_cattegoria = null;

        switch(NomeCattegoria) {

                case "Viaggio":
    
                    scelta_cattegoria = new Viaggio() ;
         
                 break;
                case "Alloggio":
        
                    scelta_cattegoria = new Alloggio() ;
                      break;

                case "Vitto":
                 
                    scelta_cattegoria = new Vitto();
                     break;

                default:
                    return null;
                 }
            // return "" + scelta_cattegoria.Disegno();
            return scelta_cattegoria;
        }
    }
}
