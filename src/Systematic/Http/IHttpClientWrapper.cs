namespace Systematic.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations of the <see cref="HttpClient"/> class.
    /// </summary>
    public interface IHttpClientWrapper : IDisposable
    {
        /// <summary>
        /// Gets or sets the base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.
        /// </summary>
        Uri? BaseAddress { get; set; }

        /// <summary>
        /// Sends an HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send.</param>
        /// <param name="completionOption">When the operation should complete (as soon as a response is available or after reading the whole response content).</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken);
    }
}
