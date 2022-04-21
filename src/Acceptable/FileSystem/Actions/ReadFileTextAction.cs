namespace Acceptable.FileSystem.Actions
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Actions;
    using Acceptable.FileSystem.Data;
    using Acceptable.Text.Data;

    /// <summary>
    /// An action to read file content as a text.
    /// </summary>
    public class ReadFileTextAction : ActionUnit<FileData, TextData>
    {
        /// <inheritdoc />
        public override string Name { get; } = "Read file as text";

        /// <inheritdoc />
        public override Task<TextData> PerformAsync(FileData input, CancellationToken cancellationToken)
        {
            var text = File.ReadAllText(input.Path);

            var result = new TextData(text);
            return Task.FromResult(result);
        }
    }
}
