namespace Systematic.Setup.Assertions
{
    using Systematic.Data;

    /// <summary>
    /// An interface of a generic expectation assertion setup.
    /// </summary>
    public interface IExpectationAssertionSetup : IAssertionSetup
    {
        /// <summary>
        /// Gets or sets an identifier by which an expectation is stored in a scope.
        /// </summary>
        DataIdentifier ExpectationId { get; set; }
    }
}
