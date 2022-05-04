namespace Systematic.Setup.Sequences
{
    using System.Collections.Generic;

    using Systematic.Setup.Steps;

    /// <summary>
    /// A setup of a step sequence.
    /// </summary>
    public abstract class SequenceSetup : ISequenceSetup
    {
        /// <summary>
        /// Setups of steps in the sequence setup.
        /// </summary>
        private readonly List<IStepSetup> _steps = new List<IStepSetup>();

        /// <inheritdoc />
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc />
        public ScopeIdentifier Scope { get; set; } = ScopeIdentifier.New;

        /// <inheritdoc />
        public IReadOnlyCollection<IStepSetup> Steps => _steps;

        /// <summary>
        /// Gets setups of steps in the sequence that can be modified in a derived class.
        /// </summary>
        protected List<IStepSetup> MutableSteps => _steps;
    }
}
