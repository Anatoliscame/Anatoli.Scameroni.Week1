using Spesa_Test.Factory;
using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test
{
    internal class Servizio
    {
        public DateTime Data_s { get; set; }
        //public string Categoria { get; set; }
        public ICategoria Categoria { get; set; }
        
        public string Descrizione { get; set; }
        public double Importo { get; set; }

        public Servizio() { }
       // double ris_importo = 0;
        public Servizio(DateTime d, ICategoria categoria, string descr, double imp)
        {
            Data_s = d;
            Categoria = categoria;
            Descrizione = descr;
            Importo = imp;
            // ris_importo =  Categoria.Importo_RimborsatoProdotto(new Servizio(Data_s, Categoria, Descrizione, Importo));
        }


        public  string Disegna()
        {
            return $"Data = {Data_s}, Categoria = {Categoria.nomeC()}, Descrizione = {Descrizione}";//, Importo = {Importo}";
        }
    }
}
