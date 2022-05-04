namespace Systematic.Setup.Assertions
{
    using Systematic.Data;

    /// <summary>
    /// A setup of an assertion.
    /// </summary>
    public abstract class AssertionSetup : IAssertionSetup
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public DataIdentifier InputId { get; set; }
    }
}
