namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="class"/> inherits a sealed override for the <see cref="object.Equals(object)"/> method.
    /// </summary>
    /// <param name="class">
    /// The <paramref name="class"/> to be checked.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> inherits a sealed override for the <see cref="object.Equals(object)"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool InheritsSealedEquals(this INamedTypeSymbol @class)
    {
        return @class.InheritsSealed(
            nameof(Equals),
            SpecialType.System_Boolean,
            predicate: method => method.Parameters.Length == 1 && method.Parameters[0].Type.SpecialType == SpecialType.System_Object);
    }
}