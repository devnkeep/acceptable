namespace Systematic.Setup.Tests.Assertions.Fixture
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;
    using Systematic.Setup.Tests.Fixture;

    internal class PlainAssertionStub : PlainAssertion<DataItemStub>
    {
        public override string Name { get; } = nameof(PlainAssertionStub);

        public override Task<AssertionResult> AssertAsync(DataItemStub input, CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
