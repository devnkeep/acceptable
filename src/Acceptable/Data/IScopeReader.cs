namespace Acceptable.Data
{
    using Acceptable.Data.Scope;

    /// <summary>
    /// Provides functionality for reading data from a scope.
    /// </summary>
    internal interface IScopeReader
    {
        /// <summary>
        /// Gets a data scope.
        /// </summary>
        IReadableScope Scope { get; }

        /// <summary>
        /// Specifies a data scope.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        void SpecifyScope(IReadableScope scope);
    }
}
