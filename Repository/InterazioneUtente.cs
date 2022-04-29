using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol.Repository
{
    internal static class InterazioneUtente
    {
        static RepositoryProdotTecnologiciMOCK repoTecnol = new RepositoryProdotTecnologiciMOCK();
        static RepositoryAlimentariMOCK repoAlim = new RepositoryAlimentariMOCK();

        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {

                int scegli_prodotto = MenuProdotti();

                switch (scegli_prodotto)
                {
                    case 1:
                        VisualizzaTuttiProdotti();
                        break;
                    case 2:
       
                        int scelta_alim = MenuAlim();
                        switch (scelta_alim)
                        {
                            case 1:
                                VisualizzaSoloAlim();
                                break;
                            case 2:
                                AggiungiAlim();
                                break;
                            case 3:
                                RicercaAlimPerNome();
                                continua = false;
                                Console.WriteLine("Arrivederci!");
                                break;
                               
                            case 4:
                                VisalizzaGiornoScadenzOggi();
                                break;
                            case 5:
                                VisualizzapAlimScadenTreGiorni();
                                break;
                            default:
                                Console.WriteLine("Scelta errata.!");
                                break;
                        }
                        break;
                    case 3:

                        int scelta_tecnol = MenuProdotTecnol();
                        switch (scelta_tecnol)
                        {
                            case 1:
                                 VisualizzaSoloTecnol();
                                break;
                            case 2:
                                AggiungiTecnol();
                                break;
                            case 3:
                                RicercaTecnolPerNome();
                                continua = false;
                                Console.WriteLine("Arrivederci!");
                                break;
                            default:
                                Console.WriteLine("Scelta errata.!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Scelta errata.!");
                        break;
                }
            }
        }






        private static void VisualizzaTuttiProdotti()
        {
            var listaAlimRecuperata = repoAlim.GetAll();
            var listaTecnolRecuperata = repoTecnol.GetAll();
            if (listaAlimRecuperata.Count == 0 || listaTecnolRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {

                Console.WriteLine("Ecco dell'elenco dei alimentari e tecnologici");
                foreach (var a in listaAlimRecuperata)
                {
                    Console.WriteLine(a.Disegno());
                }
                foreach (var t in listaTecnolRecuperata)
                {
                    Console.WriteLine(t.Disegno());
                }
            }
        }


        private static void VisualizzaSoloAlim()
        {
            var listaAlimRecuperata = repoAlim.GetAll();

            if (listaAlimRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {

                Console.WriteLine("Ecco dell'elenco dei alimentari");
                foreach (var a in listaAlimRecuperata)
                {
                    Console.WriteLine(a.Disegno());
                }
            }
        }



        private static void VisualizzaSoloTecnol()
        {
             var listaTecnolRecuperata = repoTecnol.GetAll();
            if (listaTecnolRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {

                Console.WriteLine("Ecco dell'elenco dei tecnologici");
 
                foreach (var t in listaTecnolRecuperata)
                {
                    Console.WriteLine(t.Disegno());
                }
            }
        }


        private static void VisualizzapAlimScadenTreGiorni(){
            int n = -1;
            var listaAlim = repoAlim.GetAll();
            if (listaAlim.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            for (int i=0; i < listaAlim.Count; i++)
            {
                int giorni_scad = listaAlim[i].GiorniMancDataScaden();
                // if (listaAlim[i].GiorniMancDataScaden() >=0 && listaAlim[i].GiorniMancDataScaden() <=3)
                if (giorni_scad >= 0 && giorni_scad <= 3)
                {
                    n = 1;
                    Console.WriteLine(listaAlim[i].Disegno());
                }
               
            }
            if (n==-1)
            {
                  Console.WriteLine("Non presenta la scadenza tra meno 3 giorni");
          }
    }



        public static void VisalizzaGiornoScadenzOggi()
        {
            int n = -1;
            var listaAlim = repoAlim.GetAll();
            DateTime dataOggi = DateTime.Now;
            int day = dataOggi.Day;
            for (int i = 0; i < listaAlim.Count; i++)
            {
                int data_alim = listaAlim[i].Data_scadenza.Day;
                if (data_alim==day) {
                    n = 1;
                    Console.WriteLine(listaAlim[i].Disegno());
                }
            }
            if (n == -1)
            {
                Console.WriteLine("Non presenta la scadenza del giorno di oggi");
            }
        }

        private static void AggiungiAlim()
        {
            Console.WriteLine("Inserisci nuovo Alimentare");
            Console.WriteLine("Inserisci la quantita del nuovo Alim");
            int quantita;
            while (!int.TryParse(Console.ReadLine(), out quantita))
            {
                Console.WriteLine("Riprova. Insersci un numero.");
            };


            Console.WriteLine("Inserisci la Data del nuovo Alim");
            DateTime data_sc = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il codice del nuovo Alim");
            string codice = Console.ReadLine();

            Console.WriteLine("Inserisci la discrezione del nuovo Alim");
            string discrezione = Console.ReadLine();

            Console.WriteLine("Inserisci il prezzo del nuovo Alim");
            double prezzo;
            while (!double.TryParse(Console.ReadLine(), out prezzo))
            {
                Console.WriteLine("Riprova. Insersci un numero.");
            };

            var nuovoAlim = new Alimentare()
            {
                Quantita = quantita,
                Data_scadenza = data_sc,
                Codice = codice,
                Descrizione = discrezione,
                Prezzo = prezzo

            };

            var esito = repoAlim.Aggiungi(nuovoAlim);
            if (esito != " ")
            {
                Console.WriteLine("P Alimentare aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("Errato");
            }
        }

      

        private static bool SeNewUsed(char v)
        {
            if (v == 'N' || v == 'n')
            {
                return true;
                Console.WriteLine($"Prodotto e' nuovo {true}");
            }
            if (v == 'U' || v == 'u')
            {
                return  false;
                 Console.WriteLine($"Prodotto e' nuovo {true}");
            }
            return false;
        }

        private static void AggiungiTecnol()
        {
            Console.WriteLine("Inserisci nuovo Prodotto Tecnologico");
            Console.WriteLine("Inserisci la marca del nuovo Tecnol");
            string marca = Console.ReadLine();
            Console.WriteLine("Inserisci NuovoUsato del nuovo Tecnol");
            char c_v = Console.ReadLine()[0];
   
            bool v = SeNewUsed(c_v);

            Console.WriteLine("Inserisci il codice del nuovo Tecnol");
            string codice = Console.ReadLine();

            Console.WriteLine("Inserisci la discrezione del nuovo Tecnol");
            string discrezione = Console.ReadLine();

            Console.WriteLine("Inserisci il prezzo del nuovo Tecnol");
            double prezzo;
            while (!double.TryParse(Console.ReadLine(), out prezzo))
            {
                Console.WriteLine("Riprova. Insersci un numero.");
            };

            var nuovoTecnol = new ProdottoTecnologici()
            {
                Marca = marca,
                NuovoUsato = v,
                Codice = codice,
                Descrizione = discrezione,
                Prezzo = prezzo

            };

            var esito = repoTecnol.Aggiungi(nuovoTecnol);
            if (esito != " ")
            {
                Console.WriteLine("P Tecnologico aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("Errato");
            }
        }
  

        private static void RicercaAlimPerNome()
        {
            Console.WriteLine("Inserisci il codice del Alimentare che vuoi cercare");
            string codice = Console.ReadLine();
            var listaAlimentari = repoAlim.GetAll();
            int count = 0;
            foreach (var a in listaAlimentari)
            {
                if (a.Codice.Equals(codice))
                {               
                    Console.WriteLine(listaAlimentari[count]);
                    count++;
                    return;
                }
            }
        }

        private static void RicercaTecnolPerNome()
        {
            Console.WriteLine("Inserisci la marca del prodotto Tecnologico che vuoi cercare");
            string marca = Console.ReadLine();
            var listaTecnol = repoTecnol.GetAll();
            foreach (var t in listaTecnol)
            {
                if (t.Marca.Equals(marca))
                {
                    Console.WriteLine(t.Disegno());
                    return;
                }
            }
        }
        private static int MenuProdotti()
        {
            Console.WriteLine("------------MENU--------------");
            Console.WriteLine("1.Visualizzare tutti i prodotti presenti in store");
            Console.WriteLine("2.Alimentari");
            Console.WriteLine("3.Tecnologici");
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\nInserisci la tua scelta:");
            int sceltaUtente;
            while (!int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 3)
            {

                Console.WriteLine("Riprova. Devi inserire un numero intero.");

            }
            return sceltaUtente;
        }

        private static int MenuProdotTecnol()
        {
            Console.WriteLine("------------MENU PRODOTTI TECNOLOGICI--------------");
            Console.WriteLine("1.Visualizzare solo i prodotti Tecnologici");
            Console.WriteLine("2.Aggiungi un'  prodotto Tecnologico");
            Console.WriteLine("3.Cerca un prodotto Tecnologico per me");
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\nInserisci la tua scelta:");
            int sceltaUtente;
            while (!int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 3)
            {

                Console.WriteLine("Riprova. Devi inserire un numero intero.");

            }
            return sceltaUtente;
        }
          
        
        private static int MenuAlim()
        {

            Console.WriteLine("------------MENU ALIMENTARI--------------");
            Console.WriteLine("1.Visualizzare solo i prodotti Alimentari");
            Console.WriteLine("2.Aggiungi un' Alimentare");
            Console.WriteLine("3.Cerca un Rettangolo per me");
            Console.WriteLine("4.Visualizzare i prodotti alimentari in scadenza oggi");
            Console.WriteLine("5.Visualizzare i prodotti alimentari che scadono tra meno 3 giorni.");
            
            
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\nInserisci la tua scelta:");
             int sceltaUtente;
            while (!int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 3)
            {
                Console.WriteLine("Riprova. Devi inserire un numero intero.");

            }
            return sceltaUtente;
        }
    }
}
