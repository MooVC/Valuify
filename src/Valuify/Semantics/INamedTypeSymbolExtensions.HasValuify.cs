namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string FullyQualifiedName = $"Valuify.{Name}Attribute";
    private const string GlobalQualifiedName = $"global::{FullyQualifiedName}";
    private const string Name = nameof(Valuify);

    /// <summary>Determines whether or not the <paramref name="class"/> provided is annotated with the Valuify attribute.</summary>
    /// <param name="class">The symbol for the class to be checked for the presence of the Valuify attribute.</param>
    /// <returns>True if the Valuify attribute is present on the <paramref name="class"/>, otherwise False.</returns>
    public static bool HasValuify(this INamedTypeSymbol @class)
    {
        return @class
            .GetAttributes()
            .Select(attribute => new
            {
                Class = attribute.AttributeClass,
                Data = attribute,
            })
            .Any(attribute => attribute.Class is not null && attribute.Class.IsValuify());
    }

    private static bool IsValuify(this ITypeSymbol symbol)
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