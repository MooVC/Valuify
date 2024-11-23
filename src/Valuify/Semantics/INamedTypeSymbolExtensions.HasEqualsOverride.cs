namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> declares an override for Equals.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> overrides Equals, otherwise False.</returns>
    public static bool HasEqualsOverride(this INamedTypeSymbol @class)
    {
        return @class.HasOverride(
            nameof(Equals),
            SpecialType.System_Boolean,
            predicate: parameters => parameters.Length == 1 && parameters[0].Type.SpecialType == SpecialType.System_Object);
    }
}