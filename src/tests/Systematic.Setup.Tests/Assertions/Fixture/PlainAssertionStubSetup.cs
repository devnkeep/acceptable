namespace Systematic.Setup.Tests.Assertions.Fixture
{
    using Systematic.Assertions;
    using Systematic.Setup.Assertions;
    using Systematic.Setup.Tests.Fixture;

    internal class PlainAssertionStubSetup : AssertionSetup<DataItemStub>
    {
        public override string Name { get; } = nameof(PlainAssertionStub);

        protected override PlainAssertion<DataItemStub> BuildAssertion() => new PlainAssertionStub();
    }
}
