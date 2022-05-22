namespace Systematic.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Wraps operations of the <see cref="HttpClient"/> class.
    /// </summary>
    public sealed class HttpClientWrapper : IHttpClientWrapper
    {
        /// <summary>
        /// Underlying <see cref="HttpClient"/> instance.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// A value indicating that the instance has been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper"/> class.
        /// </summary>
        /// <param name="httpClient">Underlying <see cref="HttpClient"/> instance.</param>
        public HttpClientWrapper(HttpClient httpClient) => _httpClient = httpClient;

        /// <inheritdoc/>
        public Uri? BaseAddress
        {
            get => _httpClient.BaseAddress;
            set => _httpClient.BaseAddress = value;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposed) return;

            _httpClient.Dispose();
            _disposed = true;
        }

        /// <inheritdoc />
        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken) =>
            _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
    }
}
