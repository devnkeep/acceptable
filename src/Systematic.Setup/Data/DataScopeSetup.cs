namespace Systematic.Setup.Data
{
    using System.Collections.Generic;

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
        /// Gets an ID of a data scope.
        /// </summary>
        public ScopeIdentifier Id { get; } = ScopeIdentifier.New;

        /// <summary>
        /// Gets setups of data items that should be stored in a scope at the time of its creation.
        /// </summary>
        public IReadOnlyCollection<DataItemSetup> Data => _data;

        /// <summary>
        /// Adds a data item setup to the data scope setup.
        /// </summary>
        /// <param name="setup">A data item setup.</param>
        public void AddData(DataItemSetup setup) => _data.Add(setup);

        /// <summary>
        /// Removes a data item setup from the data scope setup.
        /// </summary>
        /// <param name="setup">A data item setup.</param>
        public void RemoveData(DataItemSetup setup) => _data.Remove(setup);
    }
}
