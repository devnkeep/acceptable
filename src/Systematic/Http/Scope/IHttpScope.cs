namespace Systematic.Http.Scope
{
    using System;

    /// <summary>
    /// An interface of an HTTP scope that stores settings and current state of an HTTP client.
    /// </summary>
    public interface IHttpScope : IDisposable
    {
        /// <summary>
        /// Gets an HTTP client instance.
        /// </summary>
        IHttpClientWrapper Client { get; }
    }
}
