namespace Systematic.Setup.AssertionSteps
{
    using System.Collections.Generic;

    using Systematic.Actions;
    using Systematic.Data.Scope;
    using Systematic.Setup.Actions;
    using Systematic.Setup.Steps;

    /// <summary>
    /// An assertion step setup that can contain simple action setups.
    /// </summary>
    public class SimpleAssertionStepSetup : AssertionStepSetup, ISimpleStepSetup
    {
        /// <inheritdoc />
        public void AddAction(ISimpleActionSetup setup) => MutableActions.Add(setup);

        /// <inheritdoc />
        public void RemoveAction(ISimpleActionSetup setup) => MutableActions.Remove(setup);

        /// <inheritdoc />
        protected override IEnumerable<ActionContext> BuildActions(IReadableScope scope)
        {
            foreach (var actionSetup in Actions)
            {
                var action = actionSetup.Build(scope);
                yield return action;
            }
        }
    }
}
