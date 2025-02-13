namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="ISymbol"/>.
/// </summary>
internal static partial class ISymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> provided is annotated with the attribute denoted by the <paramref name="predicate"/>.
    /// </summary>
    /// <param name="symbol">
    /// The symbol to be checked for the presence of the attribute.
    /// </param>
    /// <param name="predicate">
    /// The predicate that determines if the attribute on the <paramref name="symbol"/> meets the criteria for selection.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the attribute is present on the <paramref name="symbol"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasAttribute(this ISymbol symbol, Predicate<AttributeData> predicate)
    {
        return symbol
            .GetAttributes()
            .Any(attribute => predicate(attribute));
    }
}