namespace Acceptable
{
    /// <summary>
    /// A result that is generated when all steps in a sequence are executed.
    /// </summary>
    public class SequenceResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether all steps in a sequence were executed successfully.
        /// </summary>
        public bool Success { get; set; } = true;
    }
}
