namespace Systematic.Setup.Tests.Fixture
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;

    internal class PlainAssertionStub : PlainAssertion<DataItemStub>
    {
        public override string Name { get; } = nameof(PlainAssertionStub);

        public override Task<AssertionResult> AssertAsync(DataItemStub input, CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
