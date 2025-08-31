namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string EquatableTypeName = "System.IEquatable`1";

    /// <summary>
    /// Determines whether or not the <paramref name="class"/> implements <see cref="IEquatable{T}"/>.
    /// </summary>
    /// <param name="class">
    /// The symbol for the class to be checked for the declaration.
    /// </param>
    /// <param name="compilation">
    /// The <see cref="Compilation"/> used to source the symbol for <see cref="IEquatable{T}"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> declares that it implements <see cref="IEquatable{T}"/>, otherwise <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The <paramref name="class"/> is assumed to be a class.
    /// </remarks>
    public static bool IsEquatable(this INamedTypeSymbol @class, Compilation compilation)
    {
        INamedTypeSymbol? equatable = compilation.GetTypeByMetadataName(EquatableTypeName);

        if (equatable is null)
        {
            return false;
        }

        bool IsEquatable(INamedTypeSymbol @interface)
        {
            return @interface.ConstructedFrom.Equals(equatable, SymbolEqualityComparer.Default)
                && @interface.TypeArguments.Length == 1
                && @interface.TypeArguments[0].Equals(@class, SymbolEqualityComparer.Default);
        }

        return @class.AllInterfaces.Any(IsEquatable);
    }
}