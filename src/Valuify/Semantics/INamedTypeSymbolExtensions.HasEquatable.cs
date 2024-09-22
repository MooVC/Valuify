namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> declares an implementaton for Equals.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> implements Equals, otherwise False.</returns>
    public static bool HasEquatable(this INamedTypeSymbol @class)
    {
        return @class
            .GetMembers(nameof(Equals))
            .OfType<IMethodSymbol>()
            .Any(method => method.ReturnType.SpecialType == SpecialType.System_Boolean
                        && method.Parameters.Length == 1
                        && SymbolEqualityComparer.Default.Equals(method.Parameters[0].Type.OriginalDefinition, @class));
    }
}