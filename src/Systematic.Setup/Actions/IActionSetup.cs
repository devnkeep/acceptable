namespace Systematic.Setup.Actions
{
    using System;

    using Systematic.Actions;
    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// An interface of an action.
    /// </summary>
    public interface IActionSetup
    {
        /// <summary>
        /// Gets an action name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets an identifier by which an action input is stored in a scope.
        /// </summary>
        DataIdentifier InputId { get; set; }

        /// <summary>
        /// Gets or sets an identifier by which an action output will be stored in a scope.
        /// </summary>
        DataIdentifier OutputId { get; set; }

        /// <summary>
        /// Builds an action context based on the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>An action context.</returns>
        /// <exception cref="InvalidOperationException">Input data id of an action must be set prior to build.</exception>
        ActionContext Build(IReadableScope scope);
    }
}
