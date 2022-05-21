namespace Systematic.Setup.Tests.Actions.Fixture
{
    using Systematic.Actions;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Tests.Fixture;

    internal class ActionStubSetup : ActionSetup<DataItemStub, DataItemStub>
    {
        public override string Name { get; } = nameof(ActionStub);

        protected override ActionUnit<DataItemStub, DataItemStub> BuildUnit() => new ActionStub();
    }
}
