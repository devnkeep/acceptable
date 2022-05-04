namespace Systematic.Setup.AssertionSteps
{
    using System.Collections.Generic;

    using Systematic.Setup.Assertions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A setup of an assertion step.
    /// </summary>
    public abstract class AssertionStepSetup : StepSetup, IAssertionStepSetup
    {
        /// <summary>
        /// Setups of assertions.
        /// </summary>
        private readonly List<IAssertionSetup> _assertions = new List<IAssertionSetup>();

        /// <inheritdoc />
        public IReadOnlyCollection<IAssertionSetup> Assertions => _assertions;

        /// <inheritdoc />
        public void AddAssertion(IAssertionSetup setup) => _assertions.Add(setup);

        /// <inheritdoc />
        public void RemoveAssertion(IAssertionSetup setup) => _assertions.Remove(setup);
    }
}
