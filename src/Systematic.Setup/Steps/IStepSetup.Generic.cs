namespace Systematic.Setup.Steps
{
    using Systematic.Setup.Actions;

    /// <summary>
    /// A generic step setup interface that specifies a type of an action setup available for a step.
    /// </summary>
    /// <typeparam name="TActionSetup">A type of an action setup available for a step.</typeparam>
    public interface IStepSetup<TActionSetup> : IStepSetup
        where TActionSetup : IActionSetup
    {
        /// <summary>
        /// Adds an action setup to a step setup.
        /// </summary>
        /// <param name="setup">An action setup.</param>
        void AddAction(TActionSetup setup);

        /// <summary>
        /// Removes an action setup from a step setup.
        /// </summary>
        /// <param name="setup">An action setup.</param>
        void RemoveAction(TActionSetup setup);
    }
}
