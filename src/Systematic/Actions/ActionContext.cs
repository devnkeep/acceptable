namespace Systematic.Actions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// A context of an action, which contains data and information needed for an action to be performed.
    /// </summary>
    public abstract class ActionContext : IInputConsumer, IOutputProvider
    {
        /// <summary>
        /// Gets the current data scope of the action.
        /// </summary>
        public IReadableScope Scope { get; private set; } = DataScope.Undefined;

        /// <inheritdoc />
        public DataIdentifier InputId { get; private set; } = DataIdentifier.Empty;

        /// <inheritdoc />
        public DataIdentifier OutputId { get; private set; } = DataIdentifier.Empty;

        /// <inheritdoc />
        public void SpecifyScope(IReadableScope scope) => Scope = scope;

        /// <inheritdoc />
        public void IdentifyInput(DataIdentifier identifier) => InputId = identifier;

        /// <inheritdoc />
        public void IdentifyOutput(DataIdentifier identifier) => OutputId = identifier;

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result.</returns>
        public async Task<DataItem> PerformAsync(CancellationToken cancellationToken)
        {
            var result = await PerformInnerAsync(cancellationToken).ConfigureAwait(false);
            IdentifyOutputData(result);

            return result;
        }

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result.</returns>
        protected abstract Task<DataItem> PerformInnerAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Sets an identifier to the output data so that it can be stored in a scope.
        /// </summary>
        /// <param name="data">Output data.</param>
        private void IdentifyOutputData(DataItem data)
        {
            if (OutputId.IsEmpty)
                return;

            data.Identify(OutputId);
        }
    }
}
