namespace Acceptable.Data
{
    /// <summary>
    /// An interface providing functionality to specify the way how expectation is identified.
    /// </summary>
    internal interface IExpectationConsumer
    {
        /// <summary>
        /// Gets an identifier by which an expectation is stored in a scope.
        /// </summary>
        DataIdentifier ExpectationId { get; }

        /// <summary>
        /// Specifies an expectation data identifier.
        /// </summary>
        /// <param name="identifier">An identifier of expectation data.</param>
        void IdentifyExpectation(DataIdentifier identifier);
    }
}
