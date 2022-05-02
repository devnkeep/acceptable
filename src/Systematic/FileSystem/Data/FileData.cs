namespace Systematic.FileSystem.Data
{
    using Systematic.Data;

    /// <summary>
    /// A data item containing information about a file.
    /// </summary>
    public class FileData : DataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileData"/> class.
        /// </summary>
        /// <param name="path">A path to a file.</param>
        public FileData(string path) => Path = path;

        /// <summary>
        /// Gets a path to a file.
        /// </summary>
        public string Path { get; }
    }
}
