using System;

namespace DC.Common.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException()
        {
        }

        public AddressNotFoundException(String message) : base(message)
        {
        }

        public AddressNotFoundException(String message, Exception inner) : base(message, inner)
        {
        }
    }
}
