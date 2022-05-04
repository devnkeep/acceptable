namespace Systematic.Data
{
    using System;

    /// <summary>
    /// An identifier of a data stored in a scope.
    /// </summary>
    public readonly struct DataIdentifier : IEquatable<DataIdentifier>
    {
        /// <summary>
        /// The underlying string identifier.
        /// </summary>
        private readonly string? _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataIdentifier"/> struct.
        /// </summary>
        /// <param name="identifier">The underlying string identifier.</param>
        public DataIdentifier(string identifier)
        {
            ArgumentNullException.ThrowIfNull(identifier, nameof(identifier));
            _identifier = identifier.Trim();
        }

        /// <summary>
        /// Implicitly converts a <see cref="string"/> class instance to a <see cref="DataIdentifier"/> struct instance.
        /// </summary>
        /// <param name="identifier">A <see cref="string"/> class instance.</param>
        public static implicit operator DataIdentifier(string identifier) => new DataIdentifier(identifier);

        /// <summary>
        /// Checks the equality of the <paramref name="left"/> and <paramref name="right"/> instances of the <see cref="DataIdentifier"/> struct.
        /// </summary>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        /// <returns><c>true</c> if operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(DataIdentifier left, DataIdentifier right) => left.Equals(right);

        /// <summary>
        /// Checks the inequality of the <paramref name="left"/> and <paramref name="right"/> instances of the <see cref="DataIdentifier"/> struct.
        /// </summary>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        /// <returns><c>true</c> if operands are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(DataIdentifier left, DataIdentifier right) => !(left == right);

        /// <inheritdoc/>
        public bool Equals(DataIdentifier other) => GetHashCode().Equals(other.GetHashCode());

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is DataIdentifier id && Equals(id);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(_identifier);

        /// <inheritdoc/>
        public override string? ToString() => _identifier ?? base.ToString();
    }
}
