namespace Systematic.Text.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;
    using Systematic.Text.Data;

    /// <summary>
    /// An assertion used to check if a text is not empty.
    /// </summary>
    public class TextNotEmptyAssertion : PlainAssertion<TextData>
    {
        /// <summary>
        /// The name of the assertion.
        /// </summary>
        public const string AssertionName = "Text not empty";

        /// <inheritdoc />
        public override string Name => AssertionName;

        /// <inheritdoc />
        public override Task<AssertionResult> AssertAsync(TextData input, CancellationToken cancellationToken)
        {
            var result = string.IsNullOrEmpty(input.Text)
                ? AssertionResult.Failed("Input text was empty")
                : AssertionResult.Successfull();

            return Task.FromResult(result);
        }
    }
}
