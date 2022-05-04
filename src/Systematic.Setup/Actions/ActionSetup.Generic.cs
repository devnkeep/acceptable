namespace Systematic.Setup.Actions
{
    using Systematic.Data;

    /// <summary>
    /// Describes a generic action setup that specifies input and output data types.
    /// </summary>
    /// <typeparam name="TInput">A type of an action input data.</typeparam>
    /// <typeparam name="TOutput">A type of an action output data.</typeparam>
    public abstract class ActionSetup<TInput, TOutput> : ActionSetup
        where TInput : DataItem
        where TOutput : DataItem
    {
    }
}
