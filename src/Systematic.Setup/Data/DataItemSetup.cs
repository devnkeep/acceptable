namespace Systematic.Setup.Data
{
    using System;

    using Systematic.Data;

    /// <summary>
    /// A setup of an abstract data item.
    /// </summary>
    public abstract class DataItemSetup
    {
        /// <summary>
        /// Gets or sets a data item identifier.
        /// </summary>
        public DataIdentifier Id { get; set; }

        /// <summary>
        /// Builds a data item based on the current setup.
        /// </summary>
        /// <returns>A data item.</returns>
        public DataItem Build()
        {
            if (Id == default)
                throw new InvalidOperationException("A data item id must be set.");

            var item = BuildItem();
            item.Identify(Id);

            return item;
        }

        /// <summary>
        /// Builds a data item.
        /// </summary>
        /// <returns>A data item.</returns>
        protected abstract DataItem BuildItem();
    }
}
