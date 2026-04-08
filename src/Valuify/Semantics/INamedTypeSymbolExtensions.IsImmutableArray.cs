namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string ImmutableArrayTypeName = "System.Collections.Immutable.ImmutableArray`1";

    /// <summary>
    /// Determines whether or not the <paramref name="type"/> is an <see cref="System.Collections.Immutable.ImmutableArray{T}"/>.
    /// </summary>
    /// <param name="type">
    /// The symbol for the type to be checked.
    /// </param>
    /// <param name="compilation">
    /// The <see cref="Compilation"/> used to source the symbol for <see cref="System.Collections.Immutable.ImmutableArray{T}"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="type"/> is an <see cref="System.Collections.Immutable.ImmutableArray{T}"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsImmutableArray(this ITypeSymbol type, Compilation compilation)
    {
        INamedTypeSymbol? immutableArray = compilation.GetTypeByMetadataName(ImmutableArrayTypeName);

        if (immutableArray is null || type is not INamedTypeSymbol namedType)
        {
            return false;
        }

        return namedType.ConstructedFrom.Equals(immutableArray, SymbolEqualityComparer.Default);
    }
}