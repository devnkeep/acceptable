namespace Systematic.Setup.Data
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A data scope setup registry that provides functionality for accessing and
    /// managing data scopes while ensuring setup integrity.
    /// </summary>
    public class DataScopeSetupRegistry : IDataScopeSetupRegistry
    {
        /// <summary>
        /// A dictionary of data scope setups with a scope id serving as a key.
        /// </summary>
        private readonly Dictionary<ScopeIdentifier, DataScopeSetup> _scopes = new Dictionary<ScopeIdentifier, DataScopeSetup>();

        /// <inheritdoc />
        public DataScopeSetup Create()
        {
            var setup = new DataScopeSetup();
            _scopes.Add(setup.Id, setup);

            return setup;
        }

        /// <inheritdoc />
        public DataScopeSetup Get(ScopeIdentifier id)
        {
            var setupExists = _scopes.ContainsKey(id);

            return setupExists
                ? _scopes[id]
                : throw new ArgumentException("A data scope with the specified id was not found.");
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
