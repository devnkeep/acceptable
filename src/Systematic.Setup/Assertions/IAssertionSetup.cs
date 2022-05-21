namespace Systematic.Setup.Assertions
{
    using System;

    using Systematic.Assertions;
    using Systematic.Data;
    using Systematic.Data.Scope;

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

        /// <summary>
        /// Builds an assertion context based on the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>An assertion context.</returns>
        /// <exception cref="InvalidOperationException">Input data id of an assertion must be set prior to build.</exception>
        AssertionContext Build(IReadableScope scope);
    }
}
