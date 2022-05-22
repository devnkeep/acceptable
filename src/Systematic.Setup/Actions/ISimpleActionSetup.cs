namespace Systematic.Setup.Actions
{
    using System;

    using Systematic.Actions;
    using Systematic.Data.Scope;

    /// <summary>
    /// An interface that identifies a setup of a simple action that requires no external dependencies to perform.
    /// </summary>
    public interface ISimpleActionSetup : IActionSetup
    {
        /// <summary>
        /// Builds a simple action context based on the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A simple action context.</returns>
        /// <exception cref="InvalidOperationException">Input data id of an action must be set prior to build.</exception>
        ActionContext Build(IReadableScope scope);
    }
}
