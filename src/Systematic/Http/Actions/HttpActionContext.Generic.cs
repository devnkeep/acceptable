namespace Systematic.Http.Actions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Data;

    /// <summary>
    /// A generic context of an action related to HTTP requests.
    /// </summary>
    /// <typeparam name="TInput">A type of input data required for an action to be performed.</typeparam>
    /// <typeparam name="TOutput">A type of a result generated when an action is performed.</typeparam>
    public class HttpActionContext<TInput, TOutput> : HttpActionContext
        where TInput : DataItem
        where TOutput : DataItem
    {
        /// <summary>
        /// The action to be performed.
        /// </summary>
        private readonly HttpActionUnit<TInput, TOutput> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpActionContext{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        public HttpActionContext(HttpActionUnit<TInput, TOutput> action) => _action = action;

        /// <inheritdoc />
        protected override async Task<DataItem> PerformInnerAsync(CancellationToken cancellationToken) =>
            await DoPerformAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result of type <typeparamref name="TOutput"/>.</returns>
        private Task<TOutput> DoPerformAsync(CancellationToken cancellationToken)
        {
            var client = HttpScope.Client;
            var input = Scope.Get<TInput>(InputId);

            return _action.PerformAsync(input, client, cancellationToken);
        }
    }
}
