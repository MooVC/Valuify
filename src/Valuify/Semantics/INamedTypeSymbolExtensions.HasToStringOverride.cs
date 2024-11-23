namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> declares an override for ToString.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> overrides ToString, otherwise False.</returns>
    public static bool HasToStringOverride(this INamedTypeSymbol @class)
    {
        return @class.HasOverride(nameof(ToString), SpecialType.System_String);
    }
}