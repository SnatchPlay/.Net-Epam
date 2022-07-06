using System;

namespace PolynomialObject.Exceptions
{
    [Serializable]
    public class PolynomialArgumentException : Exception
    {

        public PolynomialArgumentException() : base() { }

        public PolynomialArgumentException(string message) : base(message) { }
    }
}
