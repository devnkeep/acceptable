namespace Systematic.Setup.Data
{
    using Systematic.Data;

    /// <summary>
    /// A generic setup of an abstract data item that specifies a type of data item to be generated from it.
    /// </summary>
    /// <typeparam name="TDataItem">A type of data item to be generated from a setup.</typeparam>
    public abstract class DataItemSetup<TDataItem> : DataItemSetup
        where TDataItem : DataItem
    {
        /// <inheritdoc />
        protected override DataItem BuildItem() => DoBuildItem();

        /// <summary>
        /// Builds a data item of the <typeparamref name="TDataItem"/> type.
        /// </summary>
        /// <returns>A data item of the <typeparamref name="TDataItem"/> type.</returns>
        protected abstract TDataItem DoBuildItem();
    }
}
