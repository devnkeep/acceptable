namespace Systematic.Setup.Http
{
    using Systematic.Http.Scope;

    /// <summary>
    /// A setup of an HTTP scope.
    /// </summary>
    public class HttpScopeSetup
    {
        /// <summary>
        /// An instance of an HTTP scope that has been built based on the current setup.
        /// </summary>
        private IHttpScope? _httpScope;

        /// <summary>
        /// Gets an ID of an HTTP scope.
        /// </summary>
        public ScopeIdentifier Id { get; } = ScopeIdentifier.New;

        /// <summary>
        /// Builds an HTTP scope based on the current setup.
        /// If the scope has already been built, an already existing scope instance is returned.
        /// </summary>
        /// <returns>An HTTP scope.</returns>
        public IHttpScope Build() => _httpScope ??= new HttpScope();
    }
}
