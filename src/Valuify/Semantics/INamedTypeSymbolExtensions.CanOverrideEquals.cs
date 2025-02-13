namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="class"/> can override <see cref="object.Equals(object)"/>.
    /// </summary>
    /// <param name="class">
    /// The <paramref name="class"/> to be checked.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> can override <see cref="object.Equals(object)"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool CanOverrideEquals(this INamedTypeSymbol @class)
    {
        return @class.CanOverride(
            nameof(Equals),
            SpecialType.System_Boolean,
            predicate: method => method.Parameters.Length == 1 && method.Parameters[0].Type.SpecialType == SpecialType.System_Object);
    }
}