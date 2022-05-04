namespace Systematic.Setup.Sequences
{
    using Systematic.Setup.Steps;

    /// <summary>
    /// A sequence setup that can only contain simple action setups.
    /// </summary>
    public class SimpleSequenceSetup : SequenceSetup, ISequenceSetup<ISimpleStepSetup>
    {
        /// <inheritdoc />
        public void AddStep(ISimpleStepSetup setup) => MutableSteps.Add(setup);

        /// <inheritdoc />
        public void RemoveStep(ISimpleStepSetup setup) => MutableSteps.Remove(setup);
    }
}
