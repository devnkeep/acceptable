namespace Systematic.Setup.AssertionSteps
{
    using System.Collections.Generic;

    using Systematic.Setup.Assertions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// An interface of an assertion step.
    /// </summary>
    public interface IAssertionStepSetup : IStepSetup
    {
        /// <summary>
        /// Gets setups of assertions.
        /// </summary>
        IReadOnlyCollection<IAssertionSetup> Assertions { get; }

        /// <summary>
        /// Adds an assertion setup to the step setup.
        /// </summary>
        /// <param name="setup">An assertion setup.</param>
        void AddAssertion(IAssertionSetup setup);

        /// <summary>
        /// Removes an assertion setup from the step setup.
        /// </summary>
        /// <param name="setup">An assertion setup.</param>
        void RemoveAssertion(IAssertionSetup setup);
    }
}
