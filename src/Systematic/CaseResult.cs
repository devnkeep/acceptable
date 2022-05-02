namespace Systematic
{
    /// <summary>
    /// A result that is generated when a case is tested.
    /// </summary>
    public class CaseResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether all sequences in a case were run successfully.
        /// </summary>
        public bool Success { get; set; } = true;
    }
}
