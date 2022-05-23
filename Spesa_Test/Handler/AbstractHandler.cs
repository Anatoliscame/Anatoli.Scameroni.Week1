using Spesa_Test.Handler;
using Spesa_Test.InterfaceHandlre;
using Spesa_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.InterfaceFactory
{
    internal abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler { get; set; }


        public virtual string HandleRequest(Dipendente d)
        {
            if (_nextHandler != null)

                return $"" + _nextHandler.HandleRequest(d);

            return "" + 0.0;
        }


        public IHandler SetNext(IHandler presenzaHandler)
        {
            _nextHandler = presenzaHandler;
            return _nextHandler;
        }
    }
}

