namespace Systematic.Setup
{
    using System;

    /// <summary>
    /// An identifier of a scope.
    /// </summary>
    public readonly struct ScopeIdentifier : IEquatable<ScopeIdentifier>
    {
        /// <summary>
        /// The underlying string identifier.
        /// </summary>
        private readonly string _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeIdentifier"/> struct.
        /// </summary>
        /// <param name="identifier">The underlying string identifier.</param>
        private ScopeIdentifier(string identifier) => _identifier = identifier;

        /// <summary>
        /// Gets a new instance of the <see cref="ScopeIdentifier"/> struct with a new underlying identifier.
        /// </summary>
        public static ScopeIdentifier New => new ScopeIdentifier(Guid.NewGuid().ToString());

        /// <summary>
        /// Checks the equality of the <paramref name="left"/> and <paramref name="right"/> instances of the <see cref="ScopeIdentifier"/> struct.
        /// </summary>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        /// <returns><c>true</c> if operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(ScopeIdentifier left, ScopeIdentifier right) => left.Equals(right);

        /// <summary>
        /// Checks the inequality of the <paramref name="left"/> and <paramref name="right"/> instances of the <see cref="ScopeIdentifier"/> struct.
        /// </summary>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        /// <returns><c>true</c> if operands are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(ScopeIdentifier left, ScopeIdentifier right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(ScopeIdentifier other) => GetHashCode().Equals(other.GetHashCode());

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is ScopeIdentifier id && Equals(id);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(_identifier);

        /// <inheritdoc/>
        public override string? ToString() => _identifier ?? base.ToString();
    }
}
