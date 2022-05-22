namespace Systematic.Http.Actions
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Http.Data;
    using Systematic.Text.Data;

    /// <summary>
    /// An action to send an HTTP request and return a response.
    /// </summary>
    public class SendRequestAction : HttpActionUnit<RequestData, TextData>
    {
        /// <summary>
        /// The name of the action.
        /// </summary>
        public const string ActionName = "Send HTTP request";

        /// <inheritdoc />
        public override string Name => ActionName;

        /// <inheritdoc />
        public override async Task<TextData> PerformAsync(RequestData input, IHttpClientWrapper client, CancellationToken cancellationToken)
        {
            using var message = GenerateMessage(input);
            using var response = await client.SendAsync(message, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            return new TextData(content);
        }

        /// <summary>
        /// Generates a <see cref="HttpRequestMessage"/> instance based on the passed data.
        /// </summary>
        /// <param name="data">A data item containing request parameters.</param>
        /// <returns>A <see cref="HttpRequestMessage"/> instance.</returns>
        private static HttpRequestMessage GenerateMessage(RequestData data) => new HttpRequestMessage(data.Method, data.Uri);
    }
}
