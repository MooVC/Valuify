namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string InequalityOperatorName = "op_Inequality";

    /// <summary>Determines whether or not the <paramref name="class"/> declares an its own inequality operator.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> declares the inequality operator, otherwise False.</returns>
    public static bool HasInequalityOperator(this INamedTypeSymbol @class)
    {
        return @class.HasOperator(InequalityOperatorName);
    }
}