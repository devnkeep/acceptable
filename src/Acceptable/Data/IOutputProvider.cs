namespace Acceptable.Data
{
    /// <summary>
    /// An interface providing functionality to specify the way how an output is to be identified.
    /// </summary>
    internal interface IOutputProvider
    {
        /// <summary>
        /// Gets an identifier by which an output will be stored in a scope.
        /// </summary>
        DataIdentifier OutputId { get; }

        /// <summary>
        /// Specifies an output data identifier.
        /// </summary>
        /// <param name="identifier">An identifier of output data.</param>
        void IdentifyOutput(DataIdentifier identifier);
    }
}
