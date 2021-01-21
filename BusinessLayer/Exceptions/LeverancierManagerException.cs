using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class LeverancierManagerException : Exception
    {
        public LeverancierManagerException(string message) : base(message) { }
        public LeverancierManagerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
