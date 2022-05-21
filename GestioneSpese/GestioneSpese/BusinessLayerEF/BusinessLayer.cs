using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestioneSpese.BusinessLayerEF
{
    public class BusinessLayer : IBusinessLayer
    {
            private readonly IRepositorySpese speseRepo;
            private readonly IRepositoryCategorie categorieRepo;

            public BusinessLayer(IRepositorySpese spese, IRepositoryCategorie categorie)
            {
                speseRepo = spese;
                categorieRepo = categorie;
            }


        public ICollection<Categorie> GetAllCategorie()
        {
           return categorieRepo.GetAll();
        }

        public ICollection<Spese> GetAllSpese()
        {
            return speseRepo.GetAll();
        }

        public Spese InserisciNuovoSpese(Spese nuovoSpese)
        {
          Categorie categorieRecuperato = categorieRepo.GetByIdC(nuovoSpese.CategoriaId);
            if (categorieRecuperato ==null)
            {
            return null;
            }
           return speseRepo.Add(nuovoSpese);
           
          
        }


        public Categorie AggiungiCategorie(Categorie nuovoCategorie)
        {
            //Se Id di una Categoria non esiste viene generato nuovo oggetto
            Categorie categorieRecuperato = categorieRepo.GetByIdC(nuovoCategorie.Id);
           if (categorieRecuperato == null)
            {
                return categorieRepo.Add(nuovoCategorie);

            }
             return null;
  }


        public Categorie EliminaCategorie(int idCategorieDaEliminare)
        {
            throw new NotImplementedException();
        }

        public Spese EliminaSpese(int Id)
        {
            throw new NotImplementedException();
        }

       

        public Categorie ModificaCategorie(int numR, string? nuovaCat)
        {
            throw new NotImplementedException();
        }

        public Spese ModificaDescrizioneSpese(int Id, string? descr)
        {
            throw new NotImplementedException();
        }

        public Spese ModificaSpese(string? Id, DateTime Data, string? Descrizione, string? Utente, decimal Importo, bool Approvato, int Categorie)
        {
            throw new NotImplementedException();
        }
    }
}
