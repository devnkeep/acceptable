namespace Systematic.Setup.Http.Data
{
    using System;
    using System.Net.Http;

    using Systematic.Http.Data;
    using Systematic.Setup.Data;

    /// <summary>
    /// A setup of a data item of the <see cref="RequestData"/> type.
    /// </summary>
    internal class RequestDataSetup : DataItemSetup<RequestData>
    {
        /// <summary>
        /// Gets or sets URI of a request.
        /// </summary>
        public Uri? Uri { get; set; }

        /// <summary>
        /// Gets or sets an HTTP method of a request.
        /// </summary>
        public HttpMethod? Method { get; set; }

        /// <inheritdoc />
        protected override RequestData DoBuildItem()
        {
            return Uri is not null && Method is not null
                ? new RequestData(Uri, Method)
                : throw new InvalidOperationException("Request URI and HTTP method must be set prior to build.");
        }
    }
}
