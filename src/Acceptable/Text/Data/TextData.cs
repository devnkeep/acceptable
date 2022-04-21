namespace Acceptable.Text.Data
{
    using Acceptable.Data;

    /// <summary>
    /// A data item containing text.
    /// </summary>
    public class TextData : DataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextData"/> class.
        /// </summary>
        /// <param name="text">A string containing text.</param>
        public TextData(string text) => Text = text;

        /// <summary>
        /// Gets a string containing text.
        /// </summary>
        public string Text { get; }
    }
}
