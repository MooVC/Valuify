namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> can override <see cref="object.GetHashCode()"/>.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> can override <see cref="object.GetHashCode()"/>, otherwise False.</returns>
    public static bool CanOverrideGetHashCode(this INamedTypeSymbol @class)
    {
        return @class.CanOverride(nameof(GetHashCode), SpecialType.System_Int32);
    }
}