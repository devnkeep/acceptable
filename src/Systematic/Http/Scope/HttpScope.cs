namespace Systematic.Http.Scope
{
    using System.Net.Http;

    /// <summary>
    /// HTTP scope that stores settings and current state of an HTTP client.
    /// </summary>
    public sealed class HttpScope : IHttpScope
    {
        /// <summary>
        /// HTTP client instance.
        /// </summary>
        private IHttpClientWrapper? _client;

        /// <summary>
        /// A value indicating that the instance has been disposed.
        /// </summary>
        private bool _disposed;

        /// <inheritdoc />
        public IHttpClientWrapper Client => _client ??= CreateClient();

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposed) return;

            _client?.Dispose();
            _disposed = true;
        }

        /// <summary>
        /// Creates a new <see cref="IHttpClientWrapper"/> instance.
        /// </summary>
        /// <returns>A <see cref="IHttpClientWrapper"/> instance.</returns>
        private static IHttpClientWrapper CreateClient()
        {
            var httpClient = HttpClientFactory.Create();
            return new HttpClientWrapper(httpClient);
        }
    }
}
