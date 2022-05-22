namespace Systematic.Setup.Tests.Fixture
{
    using Systematic.Assertions;
    using Systematic.Setup.Assertions;

    internal class ExpectationAssertionStubSetup : ExpectationAssertionSetup<DataItemStub>
    {
        public override string Name { get; } = nameof(ExpectationAssertionStub);

        protected override ExpectationAssertion<DataItemStub> BuildAssertion() => new ExpectationAssertionStub();
    }
}
