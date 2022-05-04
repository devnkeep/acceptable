namespace Systematic.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;

    /// <summary>
    /// A generic context of an expectation assertion, which contains data and information needed for an assertion.
    /// </summary>
    /// <typeparam name="TInput">A type of input and expected data required for an assertion.</typeparam>
    public class ExpectationAssertionContext<TInput> : AssertionContext, IExpectationConsumer
        where TInput : DataItem
    {
        /// <summary>
        /// The assertion to be executed.
        /// </summary>
        private readonly ExpectationAssertion<TInput> _assertion;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectationAssertionContext{TInput}"/> class.
        /// </summary>
        /// <param name="assertion">The assertion to be executed.</param>
        public ExpectationAssertionContext(ExpectationAssertion<TInput> assertion) => _assertion = assertion;

        /// <inheritdoc />
        public DataIdentifier ExpectationId { get; private set; }

        /// <inheritdoc />
        public void IdentifyExpectation(DataIdentifier identifier) => ExpectationId = identifier;

        /// <inheritdoc />
        public override Task<AssertionResult> AssertAsync(CancellationToken cancellationToken)
        {
            var expectation = Scope.Get<TInput>(ExpectationId);
            var input = Scope.Get<TInput>(InputId);

            return _assertion.AssertAsync(expectation, input, cancellationToken);
        }
    }
}
