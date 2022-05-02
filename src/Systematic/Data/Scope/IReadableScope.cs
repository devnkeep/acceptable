namespace Systematic.Data.Scope
{
    using Systematic.Data;

    /// <summary>
    /// A scope interface that provides functionality for reading data.
    /// </summary>
    public interface IReadableScope
    {
        /// <summary>
        /// Returns a data item from the scope by its identifier.
        /// </summary>
        /// <typeparam name="TResult">A type of a data item.</typeparam>
        /// <param name="key">A key used to find a data item in the scope.</param>
        /// <returns>A found data item.</returns>
        TResult Get<TResult>(DataIdentifier key)
            where TResult : DataItem;
    }
}
