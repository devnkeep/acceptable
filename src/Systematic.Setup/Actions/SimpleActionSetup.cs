namespace Systematic.Setup.Actions
{
    using System;

    using Systematic.Actions;
    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// Describes a generic simple action setup that specifies input and output data types.
    /// </summary>
    /// <typeparam name="TInput">A type of an action input data.</typeparam>
    /// <typeparam name="TOutput">A type of an action output data.</typeparam>
    public abstract class SimpleActionSetup<TInput, TOutput> : ActionSetup, ISimpleActionSetup
        where TInput : DataItem
        where TOutput : DataItem
    {
        /// <inheritdoc />
        public ActionContext Build(IReadableScope scope)
        {
            if (InputId == default)
                throw new InvalidOperationException("Input data id of an action must be set prior to build.");

            var context = BuildActionContext();
            context.IdentifyInput(InputId);
            context.IdentifyOutput(OutputId);
            context.SpecifyScope(scope);

            return context;
        }

        /// <summary>
        /// Builds an action unit.
        /// </summary>
        /// <returns>An action unit.</returns>
        protected abstract ActionUnit<TInput, TOutput> BuildUnit();

        /// <summary>
        /// Builds an action context.
        /// </summary>
        /// <returns>An action context.</returns>
        private ActionContext BuildActionContext()
        {
            var actionUnit = BuildUnit();
            var actionContext = new ActionContext<TInput, TOutput>(actionUnit);

            return actionContext;
        }
    }
}
