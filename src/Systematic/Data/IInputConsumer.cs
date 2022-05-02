namespace Systematic.Data
{
    /// <summary>
    /// An interface providing functionality to specify the way how input is identified.
    /// </summary>
    internal interface IInputConsumer : IScopeReader
    {
        /// <summary>
        /// Gets an identifier by which an input is stored in a scope.
        /// </summary>
        DataIdentifier InputId { get; }

        /// <summary>
        /// Specifies an input data identifier.
        /// </summary>
        /// <param name="identifier">An identifier of input data.</param>
        void IdentifyInput(DataIdentifier identifier);
    }
}
