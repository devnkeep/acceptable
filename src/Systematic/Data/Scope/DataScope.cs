namespace Systematic.Data.Scope
{
    using System;
    using System.Collections.Generic;

    using Systematic.Data;

    /// <summary>
    /// A scope of data that stores items with unique identifiers that can be considered input or output for actions and assertions.
    /// </summary>
    public class DataScope : IDataScope
    {
        /// <summary>
        /// The underlying data dictionary with identifiers used as keys.
        /// </summary>
        private readonly IDictionary<DataIdentifier, DataItem> _data = new Dictionary<DataIdentifier, DataItem>();

        /// <summary>
        /// Gets an undefined data scope not suitable for storing data.
        /// </summary>
        public static IDataScope Undefined { get; } = new UndefinedDataScope();

        /// <inheritdoc />
        public TResult Get<TResult>(DataIdentifier key)
            where TResult : DataItem
        {
            var data = _data.ContainsKey(key)
                ? _data[key]
                : throw new ArgumentException($"Could not find data in the scope with the provided key '{key}'.");

            return data is TResult result
                ? result
                : throw new ArgumentException($"Unable to cast an object of the type '{data.GetType()}' to the type '{typeof(TResult)}'.");
        }

        /// <inheritdoc />
        public void Set(DataItem data)
        {
            var dataId = data.Id;
            var dataExists = _data.ContainsKey(dataId);

            if (dataExists)
                _data[dataId] = data;
            else
                _data.Add(dataId, data);
        }
    }
}
