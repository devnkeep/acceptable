namespace Acceptable.Text.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Assertions;
    using Acceptable.Text.Data;

    /// <summary>
    /// An assertion used to check if a text is not empty.
    /// </summary>
    public class TextNotEmptyAssertion : PlainAssertion<TextData>
    {
        /// <inheritdoc />
        public override string Name { get; } = "Text not empty";

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
