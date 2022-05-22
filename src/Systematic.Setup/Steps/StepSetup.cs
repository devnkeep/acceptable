namespace Systematic.Setup.Steps
{
    using System.Collections.Generic;

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
    }
}
