namespace Systematic.Setup.FileSystem.Actions
{
    using Systematic.FileSystem.Data;
    using Systematic.Setup.Actions;

    /// <summary>
    /// A setup of an action to get information about a file.
    /// </summary>
    public class GetFileActionSetup : ActionSetup<PathData, FileData>, ISimpleActionSetup
    {
        /// <inheritdoc/>
        public override string Name { get; } = "Get file info";
    }
}
