namespace Systematic.Setup.Sequences
{
    using System;
    using System.Collections.Generic;

    using Systematic.Data.Scope;
    using Systematic.Setup.Data;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A setup of a step sequence.
    /// </summary>
    public abstract class SequenceSetup : ISequenceSetup
    {
        /// <summary>
        /// A data scope setup registry.
        /// </summary>
        private readonly IDataScopeSetupRegistry _scopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceSetup"/> class.
        /// </summary>
        /// <param name="scopes">A data scope setup registry.</param>
        protected SequenceSetup(IDataScopeSetupRegistry scopes) => _scopes = scopes;

        /// <inheritdoc />
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc />
        public ScopeIdentifier Scope { get; set; }

        /// <inheritdoc />
        public IReadOnlyCollection<IStepSetup> Steps => MutableSteps;

        /// <summary>
        /// Gets setups of steps in the sequence that can be modified in a derived class.
        /// </summary>
        protected List<IStepSetup> MutableSteps { get; } = new List<IStepSetup>();

        /// <inheritdoc />
        public Sequence Build()
        {
            var sequence = new Sequence(Name);

            var steps = BuildSteps();
            foreach (var step in steps)
                sequence.AddStep(step);

            return sequence;
        }

        /// <summary>
        /// Builds a data scope in which the sequence resides.
        /// </summary>
        /// <returns>A data scope.</returns>
        /// <exception cref="InvalidOperationException">A data scope id must be set prior to build.</exception>
        protected IDataScope BuildScope()
        {
            if (Scope == default)
                throw new InvalidOperationException("A data scope id must be set prior to build.");

            var scopeSetup = _scopes.Get(Scope);
            return scopeSetup.Build();
        }

        /// <summary>
        /// Builds steps in the sequence from their setups.
        /// </summary>
        /// <returns>A collection of steps.</returns>
        protected abstract IEnumerable<Step> BuildSteps();
    }
}
