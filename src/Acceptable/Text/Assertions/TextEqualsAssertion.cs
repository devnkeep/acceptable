namespace Acceptable.Text.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Assertions;
    using Acceptable.Text.Data;

    /// <summary>
    /// An assertion used to check if a text equals an expectation.
    /// </summary>
    public class TextEqualsAssertion : ExpectationAssertion<TextData>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "Text equals";

        /// <inheritdoc/>
        public override Task<AssertionResult> AssertAsync(TextData expectation, TextData input, CancellationToken cancellationToken)
        {
            var result = expectation.Text.Equals(input.Text)
                ? AssertionResult.Successfull()
                : AssertionResult.Failed($"Expected: '{expectation}'; actual input: '{input}'");

            return Task.FromResult(result);
        }
    }
}
