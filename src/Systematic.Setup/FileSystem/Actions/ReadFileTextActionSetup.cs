namespace Systematic.Setup.FileSystem.Actions
{
    using Systematic.Actions;
    using Systematic.FileSystem.Actions;
    using Systematic.FileSystem.Data;
    using Systematic.Setup.Actions;
    using Systematic.Text.Data;

    /// <summary>
    /// A setup of an action to read file content as a text.
    /// </summary>
    public class ReadFileTextActionSetup : SimpleActionSetup<FileData, TextData>
    {
        /// <inheritdoc />
        public override string Name { get; } = "Read file as text";

        /// <inheritdoc />
        protected override ActionUnit<FileData, TextData> BuildUnit() => new ReadFileTextAction();
    }
}
