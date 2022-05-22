namespace Systematic.Setup.AssertionSteps
{
    using System;
    using System.Collections.Generic;

    using Systematic;
    using Systematic.Assertions;
    using Systematic.Data.Scope;
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

        /// <inheritdoc />
        public override Step Build(IDataScope scope)
        {
            var step = base.Build(scope);
            if (step is not AssertionStep assertionStep)
                throw new InvalidOperationException($"The step instance has an invalid type of '{step.GetType()}'.");

            var assertions = BuildAssertions(scope);
            foreach (var assertion in assertions)
                assertionStep.AddAssertion(assertion);

            return step;
        }

        /// <inheritdoc />
        protected override Step CreateStep() => new AssertionStep(Name);

        /// <summary>
        /// Builds assertions in the step from their setups.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A collection of assertion contexts.</returns>
        private IEnumerable<AssertionContext> BuildAssertions(IDataScope scope)
        {
            foreach (var assertionSetup in Assertions)
            {
                var assertion = assertionSetup.Build(scope);
                yield return assertion;
            }
        }
    }
}
