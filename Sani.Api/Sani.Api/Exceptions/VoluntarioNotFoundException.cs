using System;

namespace Sani.Api.Exceptions
{
    public class VoluntarioNotFoundException : Exception
    {
        public VoluntarioNotFoundException() { }
        public VoluntarioNotFoundException(string message) : base(message) { }
        public VoluntarioNotFoundException(string format, params object[] args) : base(string.Format(format, args)) { }
        public VoluntarioNotFoundException(string message, Exception inner) : base(message, inner) { }
        public VoluntarioNotFoundException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}
