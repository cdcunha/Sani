using System;

namespace Sani.Api.Exceptions
{
    public class ApoiadoNotFoundException : Exception
    {
        public ApoiadoNotFoundException() { }
        public ApoiadoNotFoundException(string message) : base(message) { }
        public ApoiadoNotFoundException(string format, params object[] args) : base(string.Format(format, args)) { }
        public ApoiadoNotFoundException(string message, Exception inner) : base(message, inner) { }
        public ApoiadoNotFoundException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}
