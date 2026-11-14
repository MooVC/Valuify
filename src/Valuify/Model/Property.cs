namespace Valuify.Model
{
    using System;

    /// <summary>
    /// The definition of the <see cref="Property"/> type, which is used to capture information relating to a property that
    /// forms part of the equality calculation for the type.
    /// </summary>
    [Valuify]
    internal sealed partial class Property
    {
        public bool HasValuify { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the property is marked as ignored.
        /// </summary>
        /// <value>
        /// The value indicating whether or not the property is marked as ignored.
        /// </value>
        public bool IsIgnored { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the type associated with the property implements <see cref="IEquatable{T}"/>.
        /// </summary>
        /// <value>
        /// The value indicating whether or not the type associated with the property implements <see cref="IEquatable{T}"/>.
        /// </value>
        public bool IsEquatable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the type associated with the property is <see cref="System.Collections.Immutable.ImmutableArray{T}"/>.
        /// </summary>
        /// <value>
        /// The value indicating whether or not the type associated with the property is <see cref="System.Collections.Immutable.ImmutableArray{T}"/>.
        /// </value>
        public bool IsImmutableArray { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the type associated with the property is deemed to be a sequence.
        /// </summary>
        /// <value>
        /// The value indicating whether or not the type associated with the property is deemed to be a sequence.
        /// </value>
        public bool IsSequence { get; set; }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the fully qualified name of the property type.
        /// </summary>
        /// <value>
        /// The fully qualified name of the property type.
        /// </value>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets whether equality and hashing use this property's sequence elements.
        /// </summary>
        [Ignore]
        public bool UsesSequenceEquality => IsSequence && (IsImmutableArray || !(IsEquatable || HasValuify));
    }
}