namespace Acceptable.Assertions
{
    /// <summary>
    /// An interface of an assertion.
    /// </summary>
    public interface IAssertion
    {
        /// <summary>
        /// Gets an assertion name.
        /// </summary>
        public abstract string Name { get; }
    }
}
