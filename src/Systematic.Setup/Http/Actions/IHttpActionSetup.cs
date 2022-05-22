namespace Systematic.Setup.Http.Actions
{
    using System;

    using Systematic.Data.Scope;
    using Systematic.Http.Actions;
    using Systematic.Http.Scope;
    using Systematic.Setup.Actions;

    /// <summary>
    /// An interface that identifies a setup of an action that required an HTTP client to be performed.
    /// </summary>
    public interface IHttpActionSetup : IActionSetup
    {
        /// <summary>
        /// Builds an HTTP - related action context based on the current setup.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <param name="httpScope">An HTTP scope.</param>
        /// <returns>An HTTP - related action context.</returns>
        /// <exception cref="InvalidOperationException">Input data id of an action must be set prior to build.</exception>
        HttpActionContext Build(IReadableScope scope, IHttpScope httpScope);
    }
}
