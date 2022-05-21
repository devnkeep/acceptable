namespace Systematic.Setup.Data
{
    using System;
    using System.Collections.Generic;

    using Systematic.Data.Scope;

    /// <summary>
    /// A setup of a data scope.
    /// </summary>
    public class DataScopeSetup
    {
        /// <summary>
        /// Setups of data items that should be stored in a scope at the time of its creation.
        /// </summary>
        private readonly List<DataItemSetup> _data = new List<DataItemSetup>();

        /// <summary>
        /// An instance of a data scope that has been built based on the current setup.
        /// </summary>
        private DataScope? _dataScope;

        /// <summary>
        /// Gets an ID of a data scope.
        /// </summary>
        public ScopeIdentifier Id { get; } = ScopeIdentifier.New;

        /// <summary>
        /// Gets setups of data items that should be stored in a scope at the time of its creation.
        /// </summary>
        public IReadOnlyCollection<DataItemSetup> Data => _data;

        /// <summary>
        /// Gets a value indicating whether a data scope has already been built.
        /// </summary>
        private bool Built => _dataScope is not null;

        /// <summary>
        /// Adds a data item setup to the data scope setup.
        /// </summary>
        /// <param name="setup">A data item setup.</param>
        public void AddData(DataItemSetup setup)
        {
            ThrowIfBuilt();
            _data.Add(setup);
        }

        /// <summary>
        /// Removes a data item setup from the data scope setup.
        /// </summary>
        /// <param name="setup">A data item setup.</param>
        public void RemoveData(DataItemSetup setup)
        {
            ThrowIfBuilt();
            _data.Remove(setup);
        }

        /// <summary>
        /// Builds a data scope based on the current setup.
        /// If the scope has already been built, an already existing scope instance is returned.
        /// </summary>
        /// <returns>A data scope.</returns>
        public DataScope Build() => _dataScope ??= BuildScope();

        /// <summary>
        /// Builds a data scope based on the current setup.
        /// </summary>
        /// <returns>A data scope.</returns>
        private DataScope BuildScope()
        {
            var scope = new DataScope();

            foreach (var itemSetup in _data)
            {
                var item = itemSetup.Build();
                scope.Set(item);
            }

            return scope;
        }

        /// <summary>
        /// Checks if a data scope has already been built and throws an exception if it has.
        /// </summary>
        /// <exception cref="InvalidOperationException">Data scope setup cannot be modified after a data scope has been built.</exception>
        private void ThrowIfBuilt()
        {
            if (Built) throw new InvalidOperationException("Data scope setup cannot be modified after a data scope has been built.");
        }
    }
}
