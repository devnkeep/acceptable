namespace Systematic.Http.Data
{
    using System;
    using System.Net.Http;

    using Systematic.Data;

    /// <summary>
    /// A data item containing parameters of an HTTP request.
    /// </summary>
    public class RequestData : DataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestData"/> class.
        /// </summary>
        /// <param name="uri">URI of an HTTP request.</param>
        /// <param name="method">An HTTP method of a request.</param>
        public RequestData(Uri uri, HttpMethod method)
        {
            Method = method;
            Uri = uri;
        }

        /// <summary>
        /// Gets URI of a request.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// Gets an HTTP method of a request.
        /// </summary>
        public HttpMethod Method { get; }
    }
}
