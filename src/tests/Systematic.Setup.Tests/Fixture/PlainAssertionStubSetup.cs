namespace Systematic.Setup.Tests.Fixture
{
    using Systematic.Assertions;
    using Systematic.Setup.Assertions;

    internal class PlainAssertionStubSetup : PlainAssertionSetup<DataItemStub>
    {
        public override string Name { get; } = nameof(PlainAssertionStub);

        protected override PlainAssertion<DataItemStub> BuildAssertion() => new PlainAssertionStub();
    }
}
