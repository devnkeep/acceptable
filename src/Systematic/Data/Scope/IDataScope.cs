namespace Systematic.Data.Scope
{
    /// <summary>
    /// An interface of a data scope that stores items with unique identifiers that can be considered input or output for actions and assertions.
    /// </summary>
    public interface IDataScope : IReadableScope, IWritableScope
    {
    }
}
