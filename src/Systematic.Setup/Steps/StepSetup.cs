namespace Systematic.Setup.Steps
{
    using System.Collections.Generic;

    using Systematic.Setup.Actions;

    /// <summary>
    /// A setup of a step.
    /// </summary>
    public abstract class StepSetup : IStepSetup
    {
        /// <inheritdoc />
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc />
        public IReadOnlyCollection<IActionSetup> Actions => MutableActions;

        /// <summary>
        /// Gets setups of actions in a step that can be modified in a derived class.
        /// </summary>
        protected List<IActionSetup> MutableActions { get; } = new List<IActionSetup>();
    }
}
