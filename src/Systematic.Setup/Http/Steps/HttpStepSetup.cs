namespace Systematic.Setup.Http.Steps
{
    using System;
    using System.Collections.Generic;

    using Systematic.Actions;
    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Http.Actions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A step setup that can only contain simple and HTTP action setups.
    /// </summary>
    public class HttpStepSetup : StepSetup, IHttpStepSetup
    {
        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => MutableActions.Add(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => MutableActions.Remove(setup);

        /// <inheritdoc />
        public void AddAction(IHttpActionSetup setup) => MutableActions.Add(setup);

        /// <inheritdoc />
        public void RemoveAction(IHttpActionSetup setup) => MutableActions.Remove(setup);

        /// <inheritdoc />
        public Step Build(IDataScope scope, IHttpScope httpScope)
        {
            var step = new Step(Name);
            step.SpecifyScope(scope);

            var actions = BuildActions(scope, httpScope);
            foreach (var action in actions)
                step.AddAction(action);

            return step;
        }

        /// <summary>
        /// Builds actions in the step from their setups.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <param name="httpScope">An HTTP scope.</param>
        /// <returns>A collection of action contexts.</returns>
        protected IEnumerable<ActionContext> BuildActions(IReadableScope scope, IHttpScope httpScope)
        {
            foreach (var setup in Actions)
                yield return BuildAction(setup, scope, httpScope);
        }

        /// <summary>
        /// Builds a simple action.
        /// </summary>
        /// <param name="setup">An action setup.</param>
        /// <param name="scope">A data scope.</param>
        /// <param name="httpScope">An HTTP scope.</param>
        /// <returns>A simple action context.</returns>
        private static ActionContext BuildAction(IActionSetup setup, IReadableScope scope, IHttpScope httpScope)
        {
            return setup switch
            {
                IHttpActionSetup httpSetup => httpSetup.Build(scope, httpScope),
                ISimpleActionSetup simpleSetup => simpleSetup.Build(scope),
                _ => throw new InvalidOperationException("Actions of an HTTP step must be HTTP or simple only.")
            };
        }
    }
}
