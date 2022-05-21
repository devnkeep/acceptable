namespace Systematic.Setup.FileSystem.Data
{
    using Systematic.FileSystem.Data;
    using Systematic.Setup.Data;

    /// <summary>
    /// A setup of a data item of the <see cref="PathData"/> type.
    /// </summary>
    public class PathDataSetup : DataItemSetup<PathData>
    {
        /// <summary>
        /// Gets or sets a path value.
        /// </summary>
        public string? Path { get; set; }
    }
}
