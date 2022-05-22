namespace Systematic.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;

    /// <summary>
    /// A generic context of an assertion, which contains data and information needed for an assertion.
    /// </summary>
    /// <typeparam name="TInput">A type of input data required for an assertion.</typeparam>
    public class PlainAssertionContext<TInput> : AssertionContext
        where TInput : DataItem
    {
        /// <summary>
        /// The assertion to be executed.
        /// </summary>
        private readonly PlainAssertion<TInput> _assertion;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainAssertionContext{TInput}"/> class.
        /// </summary>
        /// <param name="assertion">The assertion to be executed.</param>
        public PlainAssertionContext(PlainAssertion<TInput> assertion) => _assertion = assertion;

        /// <inheritdoc />
        public override Task<AssertionResult> AssertAsync(CancellationToken cancellationToken)
        {
            var input = Scope.Get<TInput>(InputId);
            return _assertion.AssertAsync(input, cancellationToken);
        }
    }
}
