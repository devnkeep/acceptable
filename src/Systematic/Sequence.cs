namespace Systematic
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a sequence of steps that are performed in succession.
    /// The steps are not directly linked to each other's results (unlike actions), but have a common execution context that comes from a series.
    /// </summary>
    public class Sequence
    {
        /// <summary>
        /// Steps that are executed sequentially to complete the sequence.
        /// </summary>
        private readonly List<Step> _steps;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence"/> class.
        /// </summary>
        /// <param name="name">Sequence name.</param>
        public Sequence(string name)
        {
            Name = name;

            _steps = new List<Step>();
        }

        /// <summary>
        /// Gets the name of the sequence.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets steps that are performed sequentially to get some result.
        /// </summary>
        public IReadOnlyCollection<Step> Steps => _steps;

        /// <summary>
        /// Adds a step to the sequence.
        /// </summary>
        /// <param name="step">A step to add.</param>
        public void AddStep(Step step) => _steps.Add(step);

        /// <summary>
        /// Executes all steps required to complete the sequence.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the sequence run.</param>
        /// <returns>The sequence result.</returns>
        public async Task<SequenceResult> RunAsync(CancellationToken cancellationToken)
        {
            var result = new SequenceResult();

            foreach (var step in Steps)
            {
                var stepResult = await step.ExecuteAsync(cancellationToken).ConfigureAwait(false);
                result.Success &= stepResult.Success;
            }

            return result;
        }
    }
}
