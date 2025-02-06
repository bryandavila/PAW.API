using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Architecture.Exceptions
{
    public class PAWException : Exception
    {
        public PAWException() { }

        public PAWException(string message) : base(message) { }

        public PAWException(string message, Exception inner) : base(message, inner) { }

        // Nuevo constructor que acepta un objeto Exception
        public PAWException(Exception inner) : base(inner.Message, inner) { }
    }
}
