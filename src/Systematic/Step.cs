namespace Systematic
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Actions;
    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// A single step in a sequence. Contains several linked actions that lead to a logical outcome of a step.
    /// </summary>
    public class Step : IScopeWriter
    {
        /// <summary>
        /// The collection of actions required to complete the step.
        /// </summary>
        private readonly List<ActionContext> _actions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Step"/> class.
        /// </summary>
        /// <param name="name">Step name.</param>
        public Step(string name)
        {
            Name = name;
            Scope = DataScope.Undefined;

            _actions = new List<ActionContext>();
        }

        /// <summary>
        /// Gets the name of the step.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of actions required to complete the step.
        /// </summary>
        public IReadOnlyCollection<ActionContext> Actions => _actions;

        /// <inheritdoc />
        public IWritableScope Scope { get; private set; }

        /// <inheritdoc />
        public void SpecifyScope(IWritableScope scope) => Scope = scope;

        /// <summary>
        /// Adds an action to the step.
        /// </summary>
        /// <param name="action">An action to add.</param>
        public void AddAction(ActionContext action) => _actions.Add(action);

        /// <summary>
        /// Performs all actions required to complete the step.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the step execution.</param>
        /// <returns>The step result.</returns>
        public virtual async Task<StepResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = new StepResult();

            foreach (var action in Actions)
            {
                var actionResult = await action.PerformAsync(cancellationToken).ConfigureAwait(false);
                Scope.Set(actionResult);
            }

            return result;
        }
    }
}
