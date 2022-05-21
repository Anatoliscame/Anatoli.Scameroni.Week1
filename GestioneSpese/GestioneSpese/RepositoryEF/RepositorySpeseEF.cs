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
    internal class RepositorySpeseEF : IRepositorySpese
    {
        public Spese Add(Spese item)
        {
            using (var ctx = new SpeseCategorieContext())
            {
                ctx.Spese.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Spese item)
        {
            using (var ctx = new SpeseCategorieContext())
            {
                ctx.Spese.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public ICollection<Spese> GetAll()
        {
            using (var ctx = new SpeseCategorieContext())
            {
                return ctx.Spese.Include(p => p.Categoria).ToList();

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

        public Spese Update(Spese item)
        {
            using (var ctx = new SpeseCategorieContext())
            {
                ctx.Spese.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
