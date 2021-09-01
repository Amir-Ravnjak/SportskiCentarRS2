using System;

namespace SportskiCentarRS2.Application.Common.Exceptions
{
    public class InvalidChargeException : Exception
    {
        public InvalidChargeException(string message)
            : base(message)
        {
        }
    }
}
