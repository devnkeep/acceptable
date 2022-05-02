namespace Systematic.FileSystem.Actions
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Systematic.Actions;
    using Systematic.FileSystem.Data;

    /// <summary>
    /// An action to get information about a file.
    /// </summary>
    public class GetFileAction : ActionUnit<PathData, FileData>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "Get file info";

        /// <inheritdoc />
        public override Task<FileData> PerformAsync(PathData input, CancellationToken cancellationToken)
        {
            var fileExists = File.Exists(input.Path);
            if (fileExists)
            {
                var result = new FileData(input.Path);
                return Task.FromResult(result);
            }

            throw new FileNotFoundException("File not found.", input.Path);
        }
    }
}
