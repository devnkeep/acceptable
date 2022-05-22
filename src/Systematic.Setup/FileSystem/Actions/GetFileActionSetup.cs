namespace Systematic.Setup.FileSystem.Actions
{
    using Systematic.Actions;
    using Systematic.FileSystem.Actions;
    using Systematic.FileSystem.Data;
    using Systematic.Setup.Actions;

    /// <summary>
    /// A setup of an action to get information about a file.
    /// </summary>
    public class GetFileActionSetup : SimpleActionSetup<PathData, FileData>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "Get file info";

        /// <inheritdoc />
        protected override ActionUnit<PathData, FileData> BuildUnit() => new GetFileAction();
    }
}
