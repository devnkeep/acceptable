namespace Acceptable.Data.Scope
{
    using System;

    using Acceptable.Data;

    /// <summary>
    /// An undefined data scope not suitable for storing data.
    /// </summary>
    internal class UndefinedDataScope : IDataScope
    {
        /// <inheritdoc />
        public TResult Get<TResult>(DataIdentifier key)
            where TResult : DataItem
        {
            throw new InvalidOperationException("The current scope cannot be used to store data items.");
        }

        /// <inheritdoc />
        public void Set(DataItem data)
        {
            throw new InvalidOperationException("The current scope cannot be used to store data items.");
        }
    }
}
