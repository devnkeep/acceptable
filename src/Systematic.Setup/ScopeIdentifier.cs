namespace Systematic.Setup
{
    using System;

    /// <summary>
    /// An identifier of a scope.
    /// </summary>
    public class ScopeIdentifier : IEquatable<ScopeIdentifier>
    {
        /// <summary>
        /// The underlying string identifier.
        /// </summary>
        private readonly string _identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeIdentifier"/> class.
        /// </summary>
        /// <param name="identifier">The underlying GUID identifier.</param>
        private ScopeIdentifier(Guid identifier)
            : this(identifier.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeIdentifier"/> class.
        /// </summary>
        /// <param name="identifier">The underlying string identifier.</param>
        private ScopeIdentifier(string identifier) => _identifier = identifier;

        /// <summary>
        /// Gets a new instance of the <see cref="ScopeIdentifier"/> class with a new underlying identifier.
        /// </summary>
        public static ScopeIdentifier New => new ScopeIdentifier(Guid.NewGuid());

        /// <inheritdoc />
        public bool Equals(ScopeIdentifier? other) => other is not null && GetHashCode().Equals(other.GetHashCode());

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is ScopeIdentifier id && Equals(id);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(_identifier);

        /// <inheritdoc/>
        public override string? ToString() => _identifier;
    }
}
