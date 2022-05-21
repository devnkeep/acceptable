namespace Systematic.Setup.Tests.Actions.Fixture
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Actions;
    using Systematic.Setup.Tests.Fixture;

    internal class ActionStub : ActionUnit<DataItemStub, DataItemStub>
    {
        public override string Name { get; } = nameof(ActionStub);

        public override Task<DataItemStub> PerformAsync(DataItemStub input, CancellationToken cancellationToken) =>
            throw new System.NotImplementedException();
    }
}
