namespace Systematic.Setup.Data
{
    using System;

    /// <summary>
    /// An interface of a data scope setup registry that provides functionality for accessing and
    /// managing data scopes while ensuring setup integrity.
    /// </summary>
    public interface IDataScopeSetupRegistry
    {
        /// <summary>
        /// Creates a new setup of a data scope while adding it to the registry.
        /// </summary>
        /// <returns>A new data scope setup.</returns>
        DataScopeSetup Create();

        /// <summary>
        /// Returns an existing data scope setup.
        /// </summary>
        /// <param name="id">A data scope id.</param>
        /// <returns>A data scope setup.</returns>
        /// <exception cref="ArgumentException">A data scope with the specified id was not found.</exception>
        DataScopeSetup Get(ScopeIdentifier id);

        /// <summary>
        /// Removes an existing data scope setup.
        /// </summary>
        /// <param name="id">A data scope id.</param>
        void Remove(ScopeIdentifier id);
    }
}
