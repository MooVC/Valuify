namespace Valuify.Model;

using System.Collections.Generic;

/// <summary>
/// The definition of the <see cref="Property"/> type, which is used to capture information relating to a property that
/// forms part of the equality calculation for the type.
/// </summary>
internal sealed class Property
    : Value<Property>
{
    /// <summary>
    /// Gets or sets a value indicating whether or not the property is marked as ignored.
    /// </summary>
    /// <value>
    /// The value indicating whether or not the property is marked as ignored.
    /// </value>
    public bool IsIgnored { get; set; }

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

    /// <inheritdoc/>
    protected override IEnumerable<object> GetProperties()
    {
        yield return IsIgnored;
        yield return IsSequence;
        yield return Name;
        yield return Type;
    }
}