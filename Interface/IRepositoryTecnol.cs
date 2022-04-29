using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol.Interface
{
    internal interface IRepositoryTecnol : IRepository<ProdottoTecnologici>
    {
        public abstract List<ProdottoTecnologici> GetAll();
        public abstract string Aggiungi(ProdottoTecnologici item);//Generico
    }

}
