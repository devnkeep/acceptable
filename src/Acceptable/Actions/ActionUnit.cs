namespace Acceptable.Actions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Data;

    /// <summary>
    /// A basic action.
    /// </summary>
    /// <typeparam name="TInput">A type of input data required for an action to be performed.</typeparam>
    /// <typeparam name="TOutput">A type of a result generated when an action is performed.</typeparam>
    public abstract class ActionUnit<TInput, TOutput>
        where TInput : DataItem
        where TOutput : DataItem
    {
        /// <summary>
        /// Gets an action name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="input">Input data required to perform the action.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the action performance.</param>
        /// <returns>The action result.</returns>
        public abstract Task<TOutput> PerformAsync(TInput input, CancellationToken cancellationToken);
    }
}
