namespace Systematic.Setup.Tests.Fixture
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;

    internal class ExpectationAssertionStub : ExpectationAssertion<DataItemStub>
    {
        public override string Name { get; } = nameof(ExpectationAssertionStub);

        public override Task<AssertionResult> AssertAsync(
            DataItemStub expectation,
            DataItemStub input,
            CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
