namespace Systematic.Setup.Http
{
    using System;

    /// <summary>
    /// An interface of an HTTP scope setup registry that provides functionality for accessing and
    /// managing HTTP scopes while ensuring setup integrity.
    /// </summary>
    public interface IHttpScopeSetupRegistry
    {
        /// <summary>
        /// Creates a new setup of an HTTP scope while adding it to the registry.
        /// </summary>
        /// <returns>A new HTTP scope setup.</returns>
        HttpScopeSetup Create();

        /// <summary>
        /// Returns an existing HTTP scope setup.
        /// </summary>
        /// <param name="id">An HTTP scope id.</param>
        /// <returns>An HTTP scope setup.</returns>
        /// <exception cref="ArgumentException">An HTTP scope with the specified id was not found.</exception>
        HttpScopeSetup Get(ScopeIdentifier id);

        /// <summary>
        /// Removes an existing HTTP scope setup.
        /// </summary>
        /// <param name="id">An HTTP scope id.</param>
        void Remove(ScopeIdentifier id);
    }
}
