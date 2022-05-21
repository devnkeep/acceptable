namespace Systematic.Setup.Tests.Assertions.Fixture
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;
    using Systematic.Setup.Tests.Fixture;

    internal class ExpectationAssertionStub : ExpectationAssertion<DataItemStub>
    {
        public override string Name { get; } = nameof(ExpectationAssertionStub);

        public override Task<AssertionResult> AssertAsync(
            DataItemStub expectation,
            DataItemStub input,
            CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
