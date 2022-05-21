namespace Systematic.Setup.FileSystem.Actions
{
    using Systematic.FileSystem.Data;
    using Systematic.Setup.Actions;
    using Systematic.Text.Data;

    /// <summary>
    /// A setup of an action to read file content as a text.
    /// </summary>
    public class ReadFileTextActionSetup : ActionSetup<FileData, TextData>, ISimpleActionSetup
    {
        /// <inheritdoc />
        public override string Name { get; } = "Read file as text";
    }
}
