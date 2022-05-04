namespace Systematic.Setup.Sequences
{
    using Systematic.Setup.Steps;

    /// <summary>
    /// A generic sequence setup interface that specifies a type of a step setup available for a sequence.
    /// </summary>
    /// <typeparam name="TStepSetup">A type of a step setup available for a sequence.</typeparam>
    public interface ISequenceSetup<TStepSetup> : ISequenceSetup
        where TStepSetup : IStepSetup
    {
        /// <summary>
        /// Adds a step setup to a sequence setup.
        /// </summary>
        /// <param name="setup">A step setup.</param>
        void AddStep(TStepSetup setup);

        /// <summary>
        /// Removes a step setup from a sequence setup.
        /// </summary>
        /// <param name="setup">A step setup.</param>
        void RemoveStep(TStepSetup setup);
    }
}
