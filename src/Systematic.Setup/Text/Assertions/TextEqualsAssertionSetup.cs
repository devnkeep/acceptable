namespace Systematic.Setup.Text.Assertions
{
    using Systematic.Setup.Assertions;
    using Systematic.Text.Data;

    /// <summary>
    /// A setup of an assertion used to check if a text equals an expectation.
    /// </summary>
    public class TextEqualsAssertionSetup : ExpectationAssertionSetup<TextData>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "Text equals";
    }
}
