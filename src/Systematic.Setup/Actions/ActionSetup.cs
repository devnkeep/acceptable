namespace Systematic.Setup.Actions
{
    using Systematic.Data;

    /// <summary>
    /// A setup of an action.
    /// </summary>
    public abstract class ActionSetup : IActionSetup
    {
        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <inheritdoc/>
        public DataIdentifier InputId { get; set; } = DataIdentifier.Empty;

        /// <inheritdoc/>
        public DataIdentifier OutputId { get; set; } = DataIdentifier.Empty;
    }
}
