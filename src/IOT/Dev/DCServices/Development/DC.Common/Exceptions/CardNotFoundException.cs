using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Common.Exceptions
{
    public class CardNotFoundException : Exception
    {
        public CardNotFoundException()
        {
        }

        public CardNotFoundException(String message) : base(message)
        {
        }

        public CardNotFoundException(String message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
