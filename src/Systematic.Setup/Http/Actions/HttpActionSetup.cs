namespace Systematic.Setup.Http.Actions
{
    using System;

    using Systematic.Data;
    using Systematic.Data.Scope;
    using Systematic.Http.Actions;
    using Systematic.Http.Scope;
    using Systematic.Setup.Actions;

    /// <summary>
    /// Describes a generic HTTP action setup that specifies input and output data types.
    /// </summary>
    /// <typeparam name="TInput">A type of an action input data.</typeparam>
    /// <typeparam name="TOutput">A type of an action output data.</typeparam>
    public abstract class HttpActionSetup<TInput, TOutput> : ActionSetup, IHttpActionSetup
        where TInput : DataItem
        where TOutput : DataItem
    {
        /// <inheritdoc />
        public HttpActionContext Build(IReadableScope scope, IHttpScope httpScope)
        {
            if (InputId == default)
                throw new InvalidOperationException("Input data id of an action must be set prior to build.");

            var context = BuildActionContext();
            context.IdentifyInput(InputId);
            context.IdentifyOutput(OutputId);
            context.SpecifyScope(scope);
            context.SpecifyScope(httpScope);

            return context;
        }

        /// <summary>
        /// Builds an action unit.
        /// </summary>
        /// <returns>An action unit.</returns>
        protected abstract HttpActionUnit<TInput, TOutput> BuildUnit();

        /// <summary>
        /// Builds an HTTP action context.
        /// </summary>
        /// <returns>An HTTP action context.</returns>
        private HttpActionContext<TInput, TOutput> BuildActionContext()
        {
            var actionUnit = BuildUnit();
            var actionContext = new HttpActionContext<TInput, TOutput>(actionUnit);

            return actionContext;
        }
    }
}
