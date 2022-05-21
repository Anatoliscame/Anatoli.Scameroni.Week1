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
    public class RepositorySpeseEF : IRepositorySpese
    {
        public Spese Add(Spese item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.SpeseArray.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Spese item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.SpeseArray.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public void ElencoSpeseDiUnUtenteEF()
        {
            throw new NotImplementedException();
        }

        public ICollection<Spese> GetAll()
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                return ctx.SpeseArray.Include(p => p.Categoria).ToList();

            }
        }

        public Spese GetById(int id)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                //  return ctx.SpeseArray.Include(x => x.Categoria).FirstOrDefault(p => p.CategoriaId == id);
                return null;
            }
        }

        public void SpesaTotalePerUnaCategoriaEF()
        {
            throw new NotImplementedException();
        }

        public Spese Update(Spese item)
        {
            using (var ctx = new GestioneSpeseCategorieContext())
            {
                ctx.SpeseArray.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }

        Spese IRepositorySpese.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
