using System;

namespace MinifierLibrary.Exceptions
{
    internal class MinifierTypeNotFoundException : Exception
    {
        public MinifierTypeNotFoundException(string minifierKey)
            : this(minifierKey, null)
        { }

        public MinifierTypeNotFoundException(string minifierKey, Exception exception)
            : base(string.Format("Minifier with the type '{0}' not found.", minifierKey), exception)
        { }
    }
}