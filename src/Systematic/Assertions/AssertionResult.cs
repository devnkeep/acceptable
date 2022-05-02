namespace Systematic.Assertions
{
    /// <summary>
    /// A result of an assertion.
    /// </summary>
    public class AssertionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionResult"/> class.
        /// </summary>
        /// <param name="success">A value indicating whether an assertion succeeded.</param>
        /// <param name="message">A text message describing a current state of an assertion.</param>
        private AssertionResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        /// Gets a value indicating whether an assertion succeeded.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Gets a text message describing a current state of an assertion.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Returns an instance of the <see cref="AssertionResult"/> class with a state indicating success.
        /// </summary>
        /// <returns>An instance of the <see cref="AssertionResult"/> class.</returns>
        public static AssertionResult Successfull() => new AssertionResult(true, string.Empty);

        /// <summary>
        /// Returns an instance of the <see cref="AssertionResult"/> class with a state indicating failure.
        /// </summary>
        /// <param name="message">A text message describing an error.</param>
        /// <returns>An instance of the <see cref="AssertionResult"/> class.</returns>
        public static AssertionResult Failed(string message) => new AssertionResult(false, message);
    }
}
