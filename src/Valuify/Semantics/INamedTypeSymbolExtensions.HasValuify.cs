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

    /// <summary>
    /// Determines whether or not a type HasValuify, and that the type is declared within the same assembly as the provided
    /// <paramref name="compilation"/>.
    /// </summary>
    /// <param name="class">The class to check.</param>
    /// <param name="compilation">The compilation within which the class resides.</param>
    /// <returns>
    /// <see langword="true"/> if the type is annotated with Valuify and is within the same assembly, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasValuify(this INamedTypeSymbol @class, Compilation compilation)
    {
        return SymbolEqualityComparer.Default.Equals(@class.ContainingAssembly, compilation.Assembly)
            && @class.HasValuify();
    }
}