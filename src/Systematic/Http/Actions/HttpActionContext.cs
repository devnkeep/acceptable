namespace Systematic.Http.Actions
{
    using Systematic.Actions;
    using Systematic.Http.Scope;

    /// <summary>
    /// A context of an action related to HTTP requests.
    /// </summary>
    public abstract class HttpActionContext : ActionContext, IHttpScoped
    {
        /// <inheritdoc />
        public IHttpScope HttpScope { get; private set; } = new UndefinedHttpScope();

        /// <inheritdoc />
        public void SpecifyScope(IHttpScope scope) => HttpScope = scope;
    }
}
