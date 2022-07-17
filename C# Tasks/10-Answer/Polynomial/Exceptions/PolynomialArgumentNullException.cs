using System;

namespace PolynomialObject.Exceptions
{
    [Serializable]
    public class PolynomialArgumentNullException : Exception
    {
        public PolynomialArgumentNullException() : base() { }

        public PolynomialArgumentNullException(string message) : base(message) { }
    }
}
