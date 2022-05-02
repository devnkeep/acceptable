namespace Systematic.Data
{
    using Systematic.Data.Scope;

    /// <summary>
    /// Provides functionality for writing data to a scope.
    /// </summary>
    internal interface IScopeWriter
    {
        /// <summary>
        /// Gets a data scope.
        /// </summary>
        IWritableScope Scope { get; }

        /// <summary>
        /// Specifies a data scope.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        void SpecifyScope(IWritableScope scope);
    }
}
