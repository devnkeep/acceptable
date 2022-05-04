namespace Systematic.Setup.Steps
{
    using Systematic.Setup.Actions;

    /// <summary>
    /// A step setup that can only contain simple action setups.
    /// </summary>
    public class SimpleStepSetup : StepSetup, ISimpleStepSetup
    {
        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => MutableActions.Add(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => MutableActions.Remove(setup);
    }
}
