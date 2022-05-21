using GestioneSpese.BusinessLayerEF;
using GestioneSpese.Entita;
using GestioneSpese.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public static class MenuEF
    {


        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositorySpeseEF(), new RepositoryCategorieEF());


        public static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1: 
                   
                   VisualizzaCategorie();
                    break;
                case 2:
                   InserisciNuovoCategorie();
                    break;
                case 3:                   
             
                    break;
                case 4:  
             
                    break;
                case 5: 
                    VisualizzaElencoCompletoSpese();
                
                    break;
                case 6:
                   InserisciNuovoSpese();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }


        private static void InserisciNuovoCategorie()
        {

            Console.WriteLine("Inserisci la Categoria di spesa ");
            string categoria = Console.ReadLine();

            Categorie nuovoCategorie = new Categorie()
            {
                Categoria = categoria

            };
            var repartoC = bl.AggiungiCategorie(nuovoCategorie);
           // Console.WriteLine(repartoC.ToString());

        }


        private static void InserisciNuovoSpese()
        {
            Console.WriteLine("inserire Data di Spese");
            DateTime data_sc = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("inserire la Descrizione di Spese");
            string descrizione = Console.ReadLine();
            Console.WriteLine("Inserire il utente di Spese");
            string utente = Console.ReadLine();
            Console.WriteLine("Inserire importo di Spese");
            decimal importo;//= int.Parse(Console.ReadLine());
            while (!(decimal.TryParse(Console.ReadLine(), out importo)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            Console.WriteLine("Inserire se e' approvato della Spese");
            int approvato = int.Parse(Console.ReadLine());
            bool approvato_bbol = ApprovatoNumber(approvato);


            Console.WriteLine("Inserire ID di Categoria");
            int idCategorie;
            while (!(int.TryParse(Console.ReadLine(), out idCategorie)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }    
            
            var listaCategorie = bl.GetAllCategorie();
            if (approvato != 0)
            {
                Console.WriteLine("Inserimento di Spese e' falito");
            }
            else
            {

                foreach (var item in listaCategorie)
                {
                    if (idCategorie == item.Id)
                    {
                        idCategorie = item.Id;
                    }
                }

                Spese nuovoSpese = new Spese()
                {
                    Data = data_sc,
                    Descrizione = descrizione,
                    Utente = utente,
                    Importo = importo,
                    Approvato = approvato_bbol,
                    CategoriaId = idCategorie
                };
                var p = bl.InserisciNuovoSpese(nuovoSpese);
            
                //Console.WriteLine(p.ToString());
            }
        }



        private static bool ApprovatoNumber(int n)
        {
            int approvato = n;
            bool approvato_bbol;
            if (approvato == 0)
            {
                return approvato_bbol = true;
            }
            else
            {
                return approvato_bbol = false;
            }
        }


        private static void VisualizzaCategorie()
        {
            var listaCategorie = bl.GetAllCategorie();
            if (listaCategorie.Count == 0)
            {
                Console.WriteLine("Non ci sono Categorie");
            }
            else
            {
                Console.WriteLine("Ecco l'elenco dei Categorie presenti:");
                foreach (var item in listaCategorie)
                {
                    Console.WriteLine(item);
                }
            }
        }



        private static void VisualizzaElencoCompletoSpese()
        {
            ICollection<Spese> spese = bl.GetAllSpese();
            if (spese.Count == 0)
            {
                Console.WriteLine("Nessuno Spese presente");
            }
            else
            {
                foreach (var item in spese)
                {
                    Console.WriteLine(item);
                }
            }
        }



        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("Funzionalità Categorie");
            Console.WriteLine("1.Visualizza Categorie");
            Console.WriteLine("2.Inserisci nuovo Categorie");
            Console.WriteLine("3.Modifica Categorie");
            Console.WriteLine("4.Elimina Categorie");

            Console.WriteLine("\nFunzionalità Spese");
            Console.WriteLine("5. Visualizza l'elenco completo degli Spese");
            Console.WriteLine("6. Inserimento nuovo Spese");
            Console.WriteLine("7. Modifica Spese");//per semplicità solo email
            Console.WriteLine("8. Elimina Spese");
            Console.WriteLine("\n0. Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) ))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }

    }
}
