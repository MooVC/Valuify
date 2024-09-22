namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> declares an its own operator named <paramref name="operator"/>.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <param name="operator">The name of the operator to check.</param>
    /// <returns>True if the <paramref name="class"/> declares the operator, otherwise False.</returns>
    private static bool HasOperator(this INamedTypeSymbol @class, string @operator)
    {
        return @class
            .GetMembers()
            .OfType<IMethodSymbol>()
            .Any(method => method.MethodKind == MethodKind.UserDefinedOperator
                        && method.Name == @operator
                        && method.Parameters.Length == 2
                        && SymbolEqualityComparer.Default.Equals(method.Parameters[0].Type, @class)
                        && SymbolEqualityComparer.Default.Equals(method.Parameters[1].Type, @class));
    }
}