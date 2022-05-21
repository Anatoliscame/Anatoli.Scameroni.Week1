using GestioneSpese.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Interface
{
    internal interface IRepositoryCategorie : IRepository<Categorie>
    {
       public Categorie GetByIdC(int id);
    }
}
