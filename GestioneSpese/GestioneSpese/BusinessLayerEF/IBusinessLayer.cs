using GestioneSpese.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.BusinessLayerEF
{
    internal interface IBusinessLayer
    {

        //Elenco dei metodi/funzionalità esposte
        ICollection<Categorie> GetAllCategorie();
        Categorie AggiungiCategorie(Categorie nuovoCategorie);
        Categorie ModificaCategorie(int numR, string? nuovaCat);
        Categorie EliminaCategorie(int idCategorieDaEliminare);

        ICollection<Spese> GetAllSpese();
        Spese ModificaSpese(string? Id, DateTime Data, string? Descrizione, string? Utente, decimal Importo, bool Approvato, int Categorie);
        Spese InserisciNuovoSpese(Spese nuovoSpese);
        Spese ModificaDescrizioneSpese(int Id, string? descr);
        Spese EliminaSpese(int Id);
        ICollection<Spese> GetSpeseById(int Id);

    }
}
