namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="class"/> can override <see cref="object.ToString()"/>.
    /// </summary>
    /// <param name="class">
    /// The <paramref name="class"/> to be checked.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> can override <see cref="object.ToString()"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool CanOverrideToString(this INamedTypeSymbol @class)
    {
        return @class.CanOverride(nameof(ToString), SpecialType.System_String);
    }
}