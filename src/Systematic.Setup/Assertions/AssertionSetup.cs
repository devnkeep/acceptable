namespace Systematic.Setup.Assertions
{
    using System;

    using Systematic.Assertions;
    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// A setup of an assertion.
    /// </summary>
    public abstract class AssertionSetup : IAssertionSetup
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public DataIdentifier InputId { get; set; }

        /// <inheritdoc />
        public AssertionContext Build(IReadableScope scope)
        {
            if (InputId == default)
                throw new InvalidOperationException("Input data id of an assertion must be set prior to build.");

            var context = BuildAssertionContext();
            context.IdentifyInput(InputId);
            context.SpecifyScope(scope);

            return context;
        }

        /// <summary>
        /// Builds an assertion context.
        /// </summary>
        /// <returns>An assertion context.</returns>
        protected abstract AssertionContext BuildAssertionContext();
    }
}
