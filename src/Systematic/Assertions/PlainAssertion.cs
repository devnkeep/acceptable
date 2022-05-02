namespace Systematic.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;

    /// <summary>
    /// A basic assertion whose sole purpose is to validate something.
    /// </summary>
    /// <typeparam name="TInput">A type of input data.</typeparam>
    public abstract class PlainAssertion<TInput> : IAssertion
        where TInput : DataItem
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <summary>
        /// Performs an assertion.
        /// </summary>
        /// <param name="input">Input data required to perform an assertion.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel an assertion.</param>
        /// <returns>A task instance representing an asynchronous assertion operation.</returns>
        public abstract Task<AssertionResult> AssertAsync(TInput input, CancellationToken cancellationToken);
    }
}
