namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string FullyQualifiedName = $"Valuify.{Name}Attribute";
    private const string GlobalQualifiedName = $"global::{FullyQualifiedName}";
    private const string Name = nameof(Valuify);

    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> represents the Valuify attribute.
    /// </summary>
    /// <param name="symbol">The symbol to check.</param>
    /// <returns>True if the <paramref name="symbol"/> is the Valuify attribute, otherwise False.</returns>
    public static bool IsValuify(this ITypeSymbol symbol)
    {
        bool IsGlobal()
        {
            return symbol.ContainingNamespace.IsGlobalNamespace && symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat) == Name;
        }

        bool IsQualified()
        {
            string name = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

            return name == FullyQualifiedName || name == GlobalQualifiedName;
        }

        return IsQualified() || IsGlobal();
    }
}