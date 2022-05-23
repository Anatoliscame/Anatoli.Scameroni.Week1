
using Spesa_Test.Categoria;
using Spesa_Test.Factory;

using Spesa_Test.InterfaceFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Repository
{
    internal class RepositoryProdottoFile : IGestioneProdotti
    {
        string path = @"C:\Users\Anatoli\source\repos\Spesa_Test\Spesa_Test\Spesa_Test\Spese.txt";



        public bool Aggiungi(Servizio item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {

                sw.WriteLine($"{item.Data_s} - {item.Categoria.Name} - {item.Descrizione} - {item.Importo}");//- {item.Importo} - {item.Categoria.Importo_Rimborsato(item.Importo)}");
            }
            return true;
        }



        public List<Servizio> GetAll()
        {
            List<Servizio> prodotti = new List<Servizio>();

            List<ICategoria> cattegori = new List<ICategoria>();

            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();

                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return prodotti;
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(" - ");
                        Servizio p = new Servizio();

                        p.Data_s = DateTime.Parse(campiDellaRiga[0]);
                 
                        FactoryProdottoICattegoria factory_C = new FactoryProdottoICattegoria();
                        ICategoria ris_cattegoria = factory_C.importoRimborsatoICattegoria(campiDellaRiga[1]);

                        //string str_cattegoria = factory_C.importoRimborsatoIString(campiDellaRiga[1]);

                        // p.Categoria.Name = str_cattegoria;
                        p.Categoria = ris_cattegoria;
                        p.Descrizione = campiDellaRiga[2];
                        p.Importo = double.Parse(campiDellaRiga[3]);

                        prodotti.Add(p);
                    }
                }
                return prodotti;
            }
        }

    }
}
 