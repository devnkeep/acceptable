namespace Systematic.Setup.Actions
{
    using System;

    using Systematic.Actions;
    using Systematic.Data;
    using Systematic.Data.Scope;

    /// <summary>
    /// A setup of an action.
    /// </summary>
    public abstract class ActionSetup : IActionSetup
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public DataIdentifier InputId { get; set; }

        /// <inheritdoc />
        public DataIdentifier OutputId { get; set; }

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
        /// Builds an action context.
        /// </summary>
        /// <returns>An action context.</returns>
        protected abstract ActionContext BuildActionContext();
    }
}
