namespace Systematic.Text.Assertions
{
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Assertions;
    using Systematic.Text.Data;

    /// <summary>
    /// An assertion used to check if a text equals an expectation.
    /// </summary>
    public class TextEqualsAssertion : ExpectationAssertion<TextData>
    {
        /// <summary>
        /// The name of the assertion.
        /// </summary>
        public const string AssertionName = "Text equals";

        /// <inheritdoc />
        public override string Name => AssertionName;

        /// <inheritdoc />
        public override Task<AssertionResult> AssertAsync(TextData expectation, TextData input, CancellationToken cancellationToken)
        {
            var result = expectation.Text.Equals(input.Text)
                ? AssertionResult.Successfull()
                : AssertionResult.Failed($"Expected: '{expectation}'; actual input: '{input}'");

            return Task.FromResult(result);
        }
    }
}
