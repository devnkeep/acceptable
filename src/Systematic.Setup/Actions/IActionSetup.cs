namespace Systematic.Setup.Actions
{
    using Systematic.Data;

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
    }
}
