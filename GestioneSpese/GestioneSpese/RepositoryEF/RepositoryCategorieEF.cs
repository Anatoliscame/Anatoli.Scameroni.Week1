using GestioneSpese.Entita;
using GestioneSpese.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.RepositoryEF
{
    public class RepositoryCategorieEF : IRepositoryCategorie
    {
        public Categorie Add(Categorie item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.CategorieArray.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Categorie item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.CategorieArray.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public void ElencoSpeseDiUnUtenteEF()
        {
            throw new NotImplementedException();
        }

        public ICollection<Categorie> GetAll()
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                return ctx.CategorieArray.Include(p => p.SpeseaArray).ToList();

            }
        }

        public Categorie GetByIdC(int id)
        {

            ///return GetAll().FirstOrDefault(c => c.Id == id);
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                return ctx.CategorieArray.Include(x => x.SpeseaArray).FirstOrDefault(c => c.Id == id);
            
            }
        }

        public void SpesaTotalePerUnaCategoriaEF()
        {
            throw new NotImplementedException();
        }

        public Categorie Update(Categorie item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.CategorieArray.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
