// See https://aka.ms/new-console-template for more information
using GestioneSpese.Repository;

Console.WriteLine("Hello, World!");
Console.WriteLine($"===================MENU=================");
bool quit = false;
do
{
    Console.WriteLine("1) Legge la Lista dei Spese");
    Console.WriteLine("2) Aggiungi un Spese");
    Console.WriteLine("3) Elimina un Spese a scelta");
    Console.WriteLine("4) Aggiorna un Spese a scelta");
    Console.WriteLine("5)  l'elenco delle Spese Approvate");
    Console.WriteLine("6) l'elenco delle Spese di uno specifico Utente");
    Console.WriteLine("7) Il totale delle Spese per Categorie");

    string scelta = Console.ReadLine();

    switch (scelta)
    {

        case "1":
            RepositorySpeseConnect.DataReaderSpese();
            break;
        case "2":
            RepositorySpeseConnect.InsertSpese();
            break;
        case "3":
            RepositorySpeseDisconnect.DeleteRowSpese();
            break;
        case "4":
            RepositorySpeseDisconnect.UpdateRowSpese();
            break;

        case "5":
            RepositorySpeseConnect.SpesaApprovata();
            break;
        case "6":
            // RepositorySpeseConnect.ElencoSpeseDiUnUtenteConect();
            RepositorySpeseDisconnect.ElencoSpeseDiUnUtenteDisconnect();
            break;
        case "7":
            RepositorySpeseConnect.SpesaTotalePerUnaCategoria();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto");
            break;

    }
} while (!quit);
