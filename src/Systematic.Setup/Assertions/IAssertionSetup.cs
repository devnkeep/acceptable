namespace Systematic.Setup.Assertions
{
    using Systematic.Data;

    /// <summary>
    /// An interface of an assertion setup.
    /// </summary>
    public interface IAssertionSetup
    {
        /// <summary>
        /// Gets an assertion name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets an identifier by which an assertion input is stored in a scope.
        /// </summary>
        DataIdentifier InputId { get; set; }
    }
}
