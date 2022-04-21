namespace Acceptable.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Data;

    /// <summary>
    /// An assertion base class that validates an input against expected data.
    /// </summary>
    /// <typeparam name="TInput">A type of an input and expected data.</typeparam>
    public abstract class ExpectationAssertion<TInput> : IAssertion
        where TInput : DataItem
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <summary>
        /// Performs an assertion.
        /// </summary>
        /// <param name="expectation">Expected data to validate input.</param>
        /// <param name="input">Input data to validate against expectation.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel an assertion.</param>
        /// <returns>A task instance representing an asynchronous assertion operation.</returns>
        public abstract Task<AssertionResult> AssertAsync(TInput expectation, TInput input, CancellationToken cancellationToken);
    }
}
