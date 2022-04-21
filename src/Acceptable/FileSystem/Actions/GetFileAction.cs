namespace Acceptable.FileSystem.Actions
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Acceptable.Actions;
    using Acceptable.FileSystem.Data;

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
