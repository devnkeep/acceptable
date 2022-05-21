namespace Systematic.Setup.Tests.Assertions.Fixture
{
    using Systematic.Assertions;
    using Systematic.Setup.Assertions;
    using Systematic.Setup.Tests.Fixture;

    internal class ExpectationAssertionStubSetup : ExpectationAssertionSetup<DataItemStub>
    {
        public override string Name { get; } = nameof(ExpectationAssertionStub);

        protected override ExpectationAssertion<DataItemStub> BuildAssertion() => new ExpectationAssertionStub();
    }
}
