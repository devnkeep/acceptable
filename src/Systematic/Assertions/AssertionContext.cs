namespace Systematic.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// Describes a context of an assertion, which contains data and information needed for an assertion.
    /// </summary>
    public abstract class AssertionContext : IInputConsumer
    {
        /// <inheritdoc />
        public IReadableScope Scope { get; private set; } = DataScope.Undefined;

        /// <inheritdoc />
        public DataIdentifier InputId { get; private set; } = DataIdentifier.Empty;

        /// <inheritdoc />
        public void SpecifyScope(IReadableScope scope) => Scope = scope;

        /// <inheritdoc />
        public void IdentifyInput(DataIdentifier identifier) => InputId = identifier;

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result.</returns>
        public abstract Task<AssertionResult> AssertAsync(CancellationToken cancellationToken);
    }
}
