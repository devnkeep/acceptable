namespace Systematic.Data.Scope
{
    using Systematic.Data;

    /// <summary>
    /// A scope interface that provides functionality for writing data.
    /// </summary>
    public interface IWritableScope
    {
        /// <summary>
        /// Adds or updates a data item with its identifier as a key.
        /// </summary>
        /// <param name="data">A data item to add or update.</param>
        void Set(DataItem data);
    }
}
