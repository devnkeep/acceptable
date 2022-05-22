namespace Systematic.Setup.Http
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An HTTP scope setup registry that provides functionality for accessing and
    /// managing HTTP scopes while ensuring setup integrity.
    /// </summary>
    public class HttpScopeSetupRegistry : IHttpScopeSetupRegistry
    {
        /// <summary>
        /// A dictionary of data scope setups with a scope id serving as a key.
        /// </summary>
        private readonly Dictionary<ScopeIdentifier, HttpScopeSetup> _scopes = new Dictionary<ScopeIdentifier, HttpScopeSetup>();

        /// <inheritdoc />
        public HttpScopeSetup Create()
        {
            var setup = new HttpScopeSetup();
            _scopes.Add(setup.Id, setup);

            return setup;
        }

        /// <inheritdoc />
        public HttpScopeSetup Get(ScopeIdentifier id)
        {
            var setupExists = _scopes.ContainsKey(id);

            return setupExists
                ? _scopes[id]
                : throw new ArgumentException("An HTTP scope with the specified id was not found.");
        }

        /// <inheritdoc />
        public void Remove(ScopeIdentifier id)
        {
            var setupExists = _scopes.ContainsKey(id);
            if (setupExists)
                _scopes.Remove(id);
        }
    }
}
