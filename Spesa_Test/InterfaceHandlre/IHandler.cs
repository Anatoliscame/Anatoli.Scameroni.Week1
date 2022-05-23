using Spesa_Test.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceHandlre
{
    internal interface IHandler
    {
        string HandleRequest(Dipendente d);
        IHandler SetNext(IHandler presenzaHandler);
    }
}
