namespace Systematic
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a complete test case containing several sequences of steps that should lead to an expected result.
    /// </summary>
    public class Case
    {
        /// <summary>
        /// Sequences of steps that make up the case.
        /// </summary>
        private readonly List<Sequence> _sequences;

        /// <summary>
        /// Initializes a new instance of the <see cref="Case"/> class.
        /// </summary>
        /// <param name="name">Case name.</param>
        public Case(string name)
        {
            Name = name;

            _sequences = new List<Sequence>();
        }

        /// <summary>
        /// Gets the name of the case.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets sequences of steps that make up the case.
        /// </summary>
        public IReadOnlyCollection<Sequence> Sequences => _sequences;

        /// <summary>
        /// Adds a step sequence to the case.
        /// </summary>
        /// <param name="sequence">A sequence to add.</param>
        public void AddSequence(Sequence sequence) => _sequences.Add(sequence);

        /// <summary>
        /// Runs all sequences of steps required to test the case.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the case test.</param>
        /// <returns>The case result.</returns>
        public async Task<CaseResult> TestAsync(CancellationToken cancellationToken)
        {
            var result = new CaseResult();

            foreach (var sequence in Sequences)
            {
                var sequenceResult = await sequence.RunAsync(cancellationToken).ConfigureAwait(false);
                result.Success &= sequenceResult.Success;
            }

            return result;
        }
    }
}
