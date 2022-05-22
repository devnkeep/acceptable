namespace Systematic.Setup.Http.AssertionSteps
{
    using Systematic;
    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.AssertionSteps;
    using Systematic.Setup.Http.Actions;
    using Systematic.Setup.Http.Steps;
    using Systematic.Setup.Steps;

    /// <summary>
    /// An assertion step setup that can contain HTTP and simple action setups.
    /// </summary>
    public class HttpAssertionStepSetup : AssertionStepSetup, IHttpStepSetup
    {
        /// <summary>
        /// An underlying HTTP step setup.
        /// </summary>
        private readonly IHttpStepSetup _step = new HttpStepSetup();

        /// <inheritdoc />
        protected override IStepSetup Step => _step;

        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => _step.AddAction(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => _step.RemoveAction(setup);

        /// <inheritdoc />
        public void AddAction(IHttpActionSetup setup) => _step.AddAction(setup);

        /// <inheritdoc />
        public void RemoveAction(IHttpActionSetup setup) => _step.RemoveAction(setup);

        /// <inheritdoc />
        public Step Build(IDataScope scope, IHttpScope httpScope)
        {
            var step = _step.Build(scope, httpScope);
            var assertionStep = ToAssertionStep(step);

            var assertions = BuildAssertions(scope);
            foreach (var assertion in assertions)
                assertionStep.AddAssertion(assertion);

            return assertionStep;
        }
    }
}
