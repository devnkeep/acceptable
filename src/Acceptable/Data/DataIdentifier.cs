namespace Acceptable.Data
{
    using System;

    /// <summary>
    /// An identifier of a data stored in a scope.
    /// </summary>
    public class DataIdentifier : IEquatable<DataIdentifier>
    {
        /// <summary>
        /// The underlying string identifier.
        /// </summary>
        private readonly string _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataIdentifier"/> class.
        /// </summary>
        /// <param name="identifier">The underlying string identifier.</param>
        public DataIdentifier(string identifier) => _identifier = identifier.Trim();

        /// <summary>
        /// Gets an instance of an empty identifier that is not suitable for use to be used as a data identifier.
        /// </summary>
        public static DataIdentifier Empty { get; } = new DataIdentifier(string.Empty);

        /// <summary>
        /// Gets a value indicating whether an identifier is empty.
        /// </summary>
        public bool IsEmpty => string.IsNullOrEmpty(_identifier);

        /// <summary>
        /// Implicitly converts a <see cref="string"/> class instance to a <see cref="DataIdentifier"/> class instance.
        /// </summary>
        /// <param name="identifier">A <see cref="string"/> class instance.</param>
        public static implicit operator DataIdentifier(string identifier) => new DataIdentifier(identifier);

        /// <inheritdoc/>
        public bool Equals(DataIdentifier? other) => other is not null && GetHashCode().Equals(other.GetHashCode());

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is DataIdentifier id && Equals(id);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(_identifier);

        /// <inheritdoc/>
        public override string? ToString() => _identifier;
    }
}
