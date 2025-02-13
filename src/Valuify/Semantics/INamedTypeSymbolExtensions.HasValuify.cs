namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="ISymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> provided is annotated with the Valuify attribute.
    /// </summary>
    /// <param name="symbol">
    /// The symbol for the symbol to be checked for the presence of the Valuify attribute.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the Valuify attribute is present on the <paramref name="symbol"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasValuify(this INamedTypeSymbol symbol)
    {
        return symbol.HasAttribute(attribute => attribute.AttributeClass.IsValuify());
    }
}