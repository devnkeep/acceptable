namespace Systematic.Setup.Steps
{
    using Systematic.Setup.Actions;

    /// <summary>
    /// An interface of a step setup that can only contain simple action setups.
    /// </summary>
    public interface ISimpleStepSetup : IStepSetup<ISimpleActionSetup>
    {
    }
}
