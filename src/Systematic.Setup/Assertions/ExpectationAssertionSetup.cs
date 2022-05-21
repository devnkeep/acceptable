namespace Systematic.Setup.Assertions
{
    using System;

    using Systematic.Assertions;
    using Systematic.Data;

    /// <summary>
    /// Describes a generic expectation assertion setup.
    /// </summary>
    /// <typeparam name="TExpectation">A type of expected data.</typeparam>
    public abstract class ExpectationAssertionSetup<TExpectation> : AssertionSetup, IExpectationAssertionSetup
        where TExpectation : DataItem
    {
        /// <inheritdoc />
        public DataIdentifier ExpectationId { get; set; }

        /// <inheritdoc />
        protected override AssertionContext BuildAssertionContext()
        {
            if (ExpectationId == default)
                throw new InvalidOperationException("Expectation data id of an assertion must be set prior to build.");

            var assertion = BuildAssertion();
            var assertionContext = new ExpectationAssertionContext<TExpectation>(assertion);
            assertionContext.IdentifyExpectation(ExpectationId);

            return assertionContext;
        }

        /// <summary>
        /// Builds a plain assertion.
        /// </summary>
        /// <returns>A plain assertion.</returns>
        protected abstract ExpectationAssertion<TExpectation> BuildAssertion();
    }
}
