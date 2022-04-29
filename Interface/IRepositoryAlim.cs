using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol.Interface
{
    internal interface IRepositoryAlim : IRepository<Alimentare>
    {
        public abstract List<Alimentare> GetAll();

        public abstract string Aggiungi(Alimentare item);
    }
}
