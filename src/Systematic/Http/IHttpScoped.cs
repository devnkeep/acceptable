namespace Systematic.Http
{
    using Systematic.Http.Scope;

    /// <summary>
    /// Provides functionality for accessing HTTP scope.
    /// </summary>
    internal interface IHttpScoped
    {
        /// <summary>
        /// Gets an HTTP scope.
        /// </summary>
        IHttpScope HttpScope { get; }

        /// <summary>
        /// Specifies an HTTP scope.
        /// </summary>
        /// <param name="scope">An HTTP scope.</param>
        void SpecifyScope(IHttpScope scope);
    }
}
