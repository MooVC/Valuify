namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="IPropertySymbol"/>.
/// </summary>
internal static partial class IPropertySymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="property"/> provided is annotated with the Ignore attribute.
    /// </summary>
    /// <param name="property">
    /// The property to be checked for the presence of the Ignore attribute.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the Ignore attribute is present on the <paramref name="property"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasIgnore(this IPropertySymbol property)
    {
        return property.HasAttribute(attribute => attribute.AttributeClass.IsIgnore());
    }
}