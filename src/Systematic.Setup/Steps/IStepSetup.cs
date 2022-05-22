namespace Systematic.Setup.Steps
{
    using System.Collections.Generic;

    using Systematic.Setup.Actions;

    /// <summary>
    /// An interface of a step setup.
    /// </summary>
    public interface IStepSetup
    {
        /// <summary>
        /// Gets or sets a step name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets setups of actions in a step.
        /// </summary>
        IReadOnlyCollection<IActionSetup> Actions { get; }
    }
}
