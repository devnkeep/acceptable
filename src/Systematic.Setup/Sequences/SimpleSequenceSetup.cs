namespace Systematic.Setup.Sequences
{
    using System;
    using System.Collections.Generic;

    using Systematic;
    using Systematic.Data.Scope;
    using Systematic.Setup.Data;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A sequence setup that can only contain simple action setups.
    /// </summary>
    public class SimpleSequenceSetup : SequenceSetup, ISequenceSetup<ISimpleStepSetup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSequenceSetup"/> class.
        /// </summary>
        /// <param name="scopes">A data scope setup registry.</param>
        public SimpleSequenceSetup(IDataScopeSetupRegistry scopes)
            : base(scopes)
        {
        }

        /// <inheritdoc />
        public void AddStep(ISimpleStepSetup setup) => MutableSteps.Add(setup);

        /// <inheritdoc />
        public void RemoveStep(ISimpleStepSetup setup) => MutableSteps.Remove(setup);

        /// <inheritdoc />
        protected override IEnumerable<Step> BuildSteps()
        {
            var scope = BuildScope();
            foreach (var setup in Steps)
                yield return BuildStep(setup, scope);
        }

        /// <summary>
        /// Builds a step.
        /// </summary>
        /// <param name="setup">A step setup.</param>
        /// <param name="scope">A data scope.</param>
        /// <returns>A step.</returns>
        private static Step BuildStep(IStepSetup setup, IDataScope scope)
        {
            return setup is ISimpleStepSetup simpleSetup
                ? simpleSetup.Build(scope)
                : throw new InvalidOperationException("Steps of a simple sequence must be simple only.");
        }
    }
}
