namespace Systematic.Actions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;

    /// <summary>
    /// A generic context of an action, which contains data and information needed for an action to be performed.
    /// </summary>
    /// <typeparam name="TInput">A type of input data required for an action to be performed.</typeparam>
    /// <typeparam name="TOutput">A type of a result generated when an action is performed.</typeparam>
    public class ActionContext<TInput, TOutput> : ActionContext
        where TInput : DataItem
        where TOutput : DataItem
    {
        /// <summary>
        /// The action to be performed.
        /// </summary>
        private readonly ActionUnit<TInput, TOutput> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionContext{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        public ActionContext(ActionUnit<TInput, TOutput> action) => _action = action;

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result of type <typeparamref name="TOutput"/>.</returns>
        public new Task<TOutput> PerformAsync(CancellationToken cancellationToken)
        {
            var input = Scope.Get<TInput>(InputId);
            return _action.PerformAsync(input, cancellationToken);
        }

        /// <inheritdoc />
        protected override async Task<DataItem> PerformInnerAsync(CancellationToken cancellationToken)
        {
            var result = await PerformAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
