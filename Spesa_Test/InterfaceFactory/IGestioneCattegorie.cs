
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceFactory
{
    internal interface IGestioneCattegorie : IRepositoryCattegory<ICategoria>
    {

        public abstract List<ICategoria> GetCattegory();
    }
}
