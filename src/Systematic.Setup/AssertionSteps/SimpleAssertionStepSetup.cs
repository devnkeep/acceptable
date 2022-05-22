namespace Systematic.Setup.AssertionSteps
{
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// An assertion step setup that can contain simple action setups.
    /// </summary>
    public class SimpleAssertionStepSetup : AssertionStepSetup, ISimpleStepSetup
    {
        /// <summary>
        /// An underlying simple step setup.
        /// </summary>
        private readonly ISimpleStepSetup _step = new SimpleStepSetup();

        /// <inheritdoc />
        protected override IStepSetup Step => _step;

        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => _step.AddAction(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => _step.RemoveAction(setup);

        /// <inheritdoc />
        public Step Build(IDataScope scope)
        {
            var step = _step.Build(scope);
            var assertionStep = ToAssertionStep(step);

            var assertions = BuildAssertions(scope);
            foreach (var assertion in assertions)
                assertionStep.AddAssertion(assertion);

            return assertionStep;
        }
    }
}
