namespace Systematic.Setup.Text.Data
{
    using Systematic.Setup.Data;
    using Systematic.Text.Data;

    /// <summary>
    /// A setup of a data item of the <see cref="TextData"/> type.
    /// </summary>
    public class TextDataSetup : DataItemSetup<TextData>
    {
        /// <summary>
        /// Gets or sets a text value.
        /// </summary>
        public string? Text { get; set; }
    }
}
