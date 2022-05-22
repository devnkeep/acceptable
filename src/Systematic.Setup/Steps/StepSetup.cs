namespace Systematic.Setup.Steps
{
    using System.Collections.Generic;

    using Systematic;
    using Systematic.Actions;
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;

    /// <summary>
    /// A setup of a step.
    /// </summary>
    public abstract class StepSetup : IStepSetup
    {
        /// <summary>
        /// Setups of actions.
        /// </summary>
        private readonly List<IActionSetup> _actions = new List<IActionSetup>();

        /// <inheritdoc />
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc />
        public IReadOnlyCollection<IActionSetup> Actions => _actions;

        /// <summary>
        /// Gets setups of actions in a step that can be modified in a derived class.
        /// </summary>
        protected List<IActionSetup> MutableActions => _actions;

        /// <inheritdoc />
        public virtual Step Build(IDataScope scope)
        {
            var step = CreateStep();
            step.SpecifyScope(scope);

            var actions = BuildActions(scope);
            foreach (var action in actions)
                step.AddAction(action);

            return step;
        }

        /// <summary>
        /// Creates a step instance.
        /// </summary>
        /// <returns>A step.</returns>
        protected virtual Step CreateStep() => new Step(Name);

        /// <summary>
        /// Builds actions in the step from their setups.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A collection of action contexts.</returns>
        protected abstract IEnumerable<ActionContext> BuildActions(IReadableScope scope);
    }
}
