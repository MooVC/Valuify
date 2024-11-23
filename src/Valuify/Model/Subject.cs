namespace Valuify.Model;

using System.Collections.Generic;

/// <summary>
/// The definition of the <see cref="Subject"/> type, which is used to capture information relating to a subject
/// upon which the Valuify attribute has been placed.
/// </summary>
internal sealed class Subject
    : Value<Subject>
{
    /// <summary>Gets or sets a value indicating whether or not the subject declares an equality operator.</summary>
    /// <value>A value indicating whether or not the subject declares an equality operator.</value>
    public bool HasEqualityOperator { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject overrides <see cref="object.Equals(object)"/>.</summary>
    /// <value>A value indicating whether or not the subject overrides <see cref="object.Equals(object)"/>.</value>
    public bool HasEqualsOverride { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject implements <see cref="IEquatable{T}.Equals(T)"/>.</summary>
    /// <value>A value indicating whether or not the subject implements <see cref="IEquatable{T}.Equals(T)"/>.</value>
    public bool HasEquatable { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject overrides <see cref="object.GetHashCode()"/>.</summary>
    /// <value>A value indicating whether or not the subject overrides <see cref="object.GetHashCode()"/>.</value>
    public bool HasGetHashCodeOverride { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject declares an inequality operator.</summary>
    /// <value>A value indicating whether or not the subject declares an inequality operator.</value>
    public bool HasInequalityOperator { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject overrides <see cref="object.ToString()"/>.</summary>
    /// <value>A value indicating whether or not the subject overrides <see cref="object.ToString()"/>.</value>
    public bool HasToStringOverride { get; set; }

    /// <summary>Gets or sets a value indicating whether or not the subject implements <see cref="IEquatable{T}"/>.</summary>
    /// <value>A value indicating whether or not the subject implements <see cref="IEquatable{T}"/>.</value>
    public bool IsEquatable { get; set; }

    /// <summary>Gets a value indicating whether or not the subject belongs to the global namespace.</summary>
    /// <value>A value indicating whether or not the subject belongs to the global namespace.</value>
    public bool IsGlobal => string.IsNullOrEmpty(Namespace);

    /// <summary>Gets or sets the name of the subject.</summary>
    /// <value>The name of the subject.</value>
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets or sets the globally qualified namespace for the subject.</summary>
    /// <value>The globally qualified namespace for the subject.</value>
    public string Namespace { get; set; } = string.Empty;

    /// <summary>Gets or sets the declarations associated with the parent types in order of declaration.</summary>
    /// <value>The declarations associated with the parent types in order of declaration.</value>
    public IReadOnlyList<Nesting> Nesting { get; set; } = [];

    /// <summary>Gets or sets the properties declared within the subject.</summary>
    /// <value>The properties declared within the subject.</value>
    public IReadOnlyList<Property> Properties { get; set; } = [];

    /// <summary>Gets or sets the qualified name of the subject, which includes any generic arguments.</summary>
    /// <value>The qualified name of the subject, which includes any generic arguments.</value>
    public string Qualification { get; set; } = string.Empty;

    /// <inheritdoc/>
    protected override IEnumerable<object> GetProperties()
    {
        yield return HasEqualityOperator;
        yield return HasEqualsOverride;
        yield return HasEquatable;
        yield return HasGetHashCodeOverride;
        yield return HasInequalityOperator;
        yield return HasToStringOverride;
        yield return IsEquatable;
        yield return Name;
        yield return Namespace;

        foreach (Nesting nesting in Nesting)
        {
            yield return nesting;
        }

        foreach (Property property in Properties)
        {
            yield return property;
        }

        yield return Qualification;
    }
}