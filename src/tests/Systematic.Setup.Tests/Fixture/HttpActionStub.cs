namespace Systematic.Setup.Tests.Fixture
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Http;
    using Systematic.Http.Actions;

    internal class HttpActionStub : HttpActionUnit<DataItemStub, DataItemStub>
    {
        public override string Name { get; } = nameof(HttpActionStub);

        public override Task<DataItemStub> PerformAsync(
            DataItemStub input,
            IHttpClientWrapper client,
            CancellationToken cancellationToken) =>
            throw new NotImplementedException();
    }
}
