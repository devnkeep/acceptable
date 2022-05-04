namespace Systematic.Setup.Assertions
{
    using Systematic.Data;

    /// <summary>
    /// Describes a generic expectation assertion setup.
    /// </summary>
    /// <typeparam name="TExpectation">A type of expected data.</typeparam>
    public abstract class ExpectationAssertionSetup<TExpectation> : AssertionSetup<TExpectation>, IExpectationAssertionSetup
        where TExpectation : DataItem
    {
        /// <inheritdoc />
        public DataIdentifier ExpectationId { get; set; }
    }
}
