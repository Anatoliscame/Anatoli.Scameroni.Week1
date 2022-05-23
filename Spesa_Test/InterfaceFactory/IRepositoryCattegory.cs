using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceFactory
{
    internal interface IRepositoryCattegory<T>
    {
        List<T> GetCattegory();
    }
}
