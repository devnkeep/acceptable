namespace Systematic.Setup.Steps
{
    using System;
    using System.Collections.Generic;

    using Systematic.Actions;
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;

    /// <summary>
    /// A step setup that can only contain simple action setups.
    /// </summary>
    public class SimpleStepSetup : StepSetup, ISimpleStepSetup
    {
        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => MutableActions.Add(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => MutableActions.Remove(setup);

        /// <inheritdoc />
        public Step Build(IDataScope scope)
        {
            var step = new Step(Name);
            step.SpecifyScope(scope);

            var actions = BuildActions(scope);
            foreach (var action in actions)
                step.AddAction(action);

            return step;
        }

        /// <summary>
        /// Builds actions in the step from their setups.
        /// </summary>
        /// <param name="scope">A data scope.</param>
        /// <returns>A collection of action contexts.</returns>
        protected IEnumerable<ActionContext> BuildActions(IReadableScope scope)
        {
            foreach (var setup in Actions)
                yield return BuildAction(setup, scope);
        }

        /// <summary>
        /// Builds a simple action.
        /// </summary>
        /// <param name="setup">An action setup.</param>
        /// <param name="scope">A data scope.</param>
        /// <returns>A simple action context.</returns>
        private static ActionContext BuildAction(IActionSetup setup, IReadableScope scope)
        {
            return setup is ISimpleActionSetup simpleSetup
                ? simpleSetup.Build(scope)
                : throw new InvalidOperationException("Actions of a simple step must be simple only.");
        }
    }
}
