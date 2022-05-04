namespace Systematic.Setup.Assertions
{
    using Systematic.Data;

    /// <summary>
    /// Describes a generic assertion setup specifying input data type.
    /// </summary>
    /// <typeparam name="TInput">A type of assertion input data.</typeparam>
    public abstract class AssertionSetup<TInput> : AssertionSetup
        where TInput : DataItem
    {
    }
}
