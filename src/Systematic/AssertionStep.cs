namespace Systematic
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;

    /// <summary>
    /// A special kind of step whose purpose is to validate the current state.
    /// Such a step may stop execution of the entire case if the assertion fails.
    /// </summary>
    public class AssertionStep : Step
    {
        /// <summary>
        /// The collection of assertions required to validate the current state.
        /// </summary>
        private readonly List<AssertionContext> _assertions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionStep"/> class.
        /// </summary>
        /// <param name="name">Assertion step name.</param>
        public AssertionStep(string name)
            : base(name)
        {
            _assertions = new List<AssertionContext>();
        }

        /// <summary>
        /// Gets the collection of assertions required to validate the current state.
        /// </summary>
        public IReadOnlyCollection<AssertionContext> Assertions => _assertions;

        /// <summary>
        /// Adds an assertion to the step.
        /// </summary>
        /// <param name="assertion">An assertion to add.</param>
        public void AddAssertion(AssertionContext assertion) => _assertions.Add(assertion);

        /// <inheritdoc />
        public override async Task<StepResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            var stepResult = await base.ExecuteAsync(cancellationToken).ConfigureAwait(false);

            foreach (var assertion in Assertions)
            {
                var assertionResult = await assertion.AssertAsync(cancellationToken).ConfigureAwait(false);
                stepResult.Success &= assertionResult.Success;
            }

            return stepResult;
        }
    }
}
