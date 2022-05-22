namespace Systematic.Setup.Sequences
{
    using System.Collections.Generic;

    using Systematic.Setup.Steps;

    /// <summary>
    /// An interface of a sequence setup.
    /// </summary>
    public interface ISequenceSetup
    {
        /// <summary>
        /// Gets or sets a sequence name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets setups of steps in the sequence setup.
        /// </summary>
        IReadOnlyCollection<IStepSetup> Steps { get; }

        /// <summary>
        /// Gets or sets an ID of a data scope in which the sequence resides.
        /// </summary>
        ScopeIdentifier Scope { get; set; }

        /// <summary>
        /// Builds a sequence based on the current setup.
        /// </summary>
        /// <returns>A sequence.</returns>
        Sequence Build();
    }
}
