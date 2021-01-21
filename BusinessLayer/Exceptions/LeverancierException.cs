using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class LeverancierException : Exception
    {
        public LeverancierException(string message) : base(message) { }
        public LeverancierException(string message, Exception innerException) : base(message, innerException) { }
    }
}
