namespace Systematic.Setup.Tests.Fixture
{
    using Systematic.Http.Actions;
    using Systematic.Setup.Http.Actions;

    internal class HttpActionStubSetup : HttpActionSetup<DataItemStub, DataItemStub>
    {
        public override string Name { get; } = nameof(HttpActionStubSetup);

        protected override HttpActionUnit<DataItemStub, DataItemStub> BuildUnit() => new HttpActionStub();
    }
}
