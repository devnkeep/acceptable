namespace Systematic.Setup.Steps
{
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;

    /// <summary>
    /// An interface of a step setup that can only contain simple action setups.
    /// </summary>
    public interface ISimpleStepSetup : IStepSetup<ISimpleActionSetup>
    {
        /// <summary>
        /// Builds a simple step from the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A simple step.</returns>
        Step Build(IDataScope scope);
    }
}
