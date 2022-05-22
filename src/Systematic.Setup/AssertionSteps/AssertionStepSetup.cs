namespace Systematic.Setup.AssertionSteps
{
    using System.Collections.Generic;

    using Systematic.Assertions;
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Assertions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A setup of an assertion step.
    /// </summary>
    public abstract class AssertionStepSetup : IAssertionStepSetup
    {
        /// <summary>
        /// Setups of assertions.
        /// </summary>
        private readonly List<IAssertionSetup> _assertions = new List<IAssertionSetup>();

        /// <inheritdoc />
        public IReadOnlyCollection<IAssertionSetup> Assertions => _assertions;

        /// <inheritdoc />
        public string Name
        {
            get => Step.Name;
            set => Step.Name = value;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IActionSetup> Actions => Step.Actions;

        /// <summary>
        /// Gets an underlying step setup that contains actions necessary for an assertion.
        /// </summary>
        protected abstract IStepSetup Step { get; }

        /// <inheritdoc />
        public void AddAssertion(IAssertionSetup setup) => _assertions.Add(setup);

        /// <inheritdoc />
        public void RemoveAssertion(IAssertionSetup setup) => _assertions.Remove(setup);

        /// <summary>
        /// Converts a <see cref="Systematic.Step"/> instance to a <see cref="AssertionStep"/> instance.
        /// </summary>
        /// <param name="step">A step instance.</param>
        /// <returns>An assertion step instance.</returns>
        protected static AssertionStep ToAssertionStep(Step step)
        {
            var assertionStep = new AssertionStep(step.Name);
            assertionStep.SpecifyScope(step.Scope);

            foreach (var action in step.Actions)
                assertionStep.AddAction(action);

            return assertionStep;
        }

        /// <summary>
        /// Builds assertions in the step from their setups.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A collection of assertion contexts.</returns>
        protected IEnumerable<AssertionContext> BuildAssertions(IDataScope scope)
        {
            foreach (var assertionSetup in Assertions)
            {
                var assertion = assertionSetup.Build(scope);
                yield return assertion;
            }
        }
    }
}
