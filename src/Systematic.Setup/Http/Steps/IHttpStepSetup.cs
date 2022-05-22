namespace Systematic.Setup.Http.Steps
{
    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Http.Actions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// An interface of a step setup that can only contain simple and HTTP action setups.
    /// </summary>
    public interface IHttpStepSetup : IStepSetup<ISimpleActionSetup>, IStepSetup<IHttpActionSetup>
    {
        /// <summary>
        /// Builds an HTTP step from the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <param name="httpScope">An HTTP scope.</param>
        /// <returns>An HTTP step.</returns>
        Step Build(IDataScope scope, IHttpScope httpScope);
    }
}
