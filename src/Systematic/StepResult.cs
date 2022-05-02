namespace Systematic
{
    /// <summary>
    /// A result that is generated when a step is executed.
    /// </summary>
    public class StepResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether all actions in a step were performed successfully.
        /// </summary>
        public bool Success { get; set; } = true;
    }
}
