namespace Systematic.Setup.Assertions
{
    using Systematic.Assertions;
    using Systematic.Data;

    /// <summary>
    /// Describes a generic assertion setup specifying input data type.
    /// </summary>
    /// <typeparam name="TInput">A type of assertion input data.</typeparam>
    public abstract class AssertionSetup<TInput> : AssertionSetup
        where TInput : DataItem
    {
        /// <inheritdoc />
        protected override AssertionContext BuildAssertionContext()
        {
            var assertion = BuildAssertion();
            var assertionContext = new AssertionContext<TInput>(assertion);

            return assertionContext;
        }

        /// <summary>
        /// Builds a plain assertion.
        /// </summary>
        /// <returns>A plain assertion.</returns>
        protected abstract PlainAssertion<TInput> BuildAssertion();
    }
}
