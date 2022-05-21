namespace Systematic.Setup.Data
{
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
    }
}
