namespace Acceptable.FileSystem.Data
{
    using Acceptable.Data;

    /// <summary>
    /// A data item containing a path to a file or folder.
    /// </summary>
    public class PathData : DataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathData"/> class.
        /// </summary>
        /// <param name="path">A path to a file or folder.</param>
        public PathData(string path) => Path = path;

        /// <summary>
        /// Gets a path to a file or folder.
        /// </summary>
        public string Path { get; }
    }
}
