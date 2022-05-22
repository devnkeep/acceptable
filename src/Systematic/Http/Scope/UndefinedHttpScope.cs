namespace Systematic.Http.Scope
{
    using System;

    /// <summary>
    /// An undefined HTTP scope not suitable for accessing HTTP client.
    /// </summary>
    internal class UndefinedHttpScope : IHttpScope
    {
        /// <inheritdoc />
        public IHttpClientWrapper Client => throw new InvalidOperationException("The current scope cannot be used to access HTTP client.");

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}
