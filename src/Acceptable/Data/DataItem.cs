namespace Acceptable.Data
{
    using System;

    /// <summary>
    /// A unit of data used to transfer data in a scope.
    /// </summary>
    public abstract class DataItem
    {
        /// <summary>
        /// Gets an ID of a data item.
        /// </summary>
        public DataIdentifier Id { get; private set; } = DataIdentifier.Empty;

        /// <summary>
        /// Sets an ID of a data item.
        /// </summary>
        /// <param name="id">Data ID.</param>
        /// <exception cref="InvalidOperationException">Data identifier cannot be changed after being set.</exception>
        /// <exception cref="ArgumentException">Data identifier cannot be null or empty.</exception>
        public void Identify(DataIdentifier id)
        {
            if (!Id.IsEmpty)
                throw new InvalidOperationException("Data identifier cannot be changed after being set.");

            if (id.IsEmpty)
                throw new ArgumentException("Data identifier cannot be null or empty.", nameof(id));

            Id = id;
        }
    }
}
