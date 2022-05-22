namespace Systematic.Setup.Tests.Fixture
{
    using Systematic.Actions;
    using Systematic.Setup.Actions;

    internal class ActionStubSetup : ActionSetup<DataItemStub, DataItemStub>, ISimpleActionSetup
    {
        public override string Name { get; } = nameof(ActionStub);

        protected override ActionUnit<DataItemStub, DataItemStub> BuildUnit() => new ActionStub();
    }
}
