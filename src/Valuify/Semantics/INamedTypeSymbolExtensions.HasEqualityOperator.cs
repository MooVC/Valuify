namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string EqualityOperatorName = "op_Equality";

    /// <summary>Determines whether or not the <paramref name="class"/> declares an its own equals operator.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <returns>True if the <paramref name="class"/> declares the equals operator, otherwise False.</returns>
    public static bool HasEqualityOperator(this INamedTypeSymbol @class)
    {
        return @class.HasOperator(EqualityOperatorName);
    }
}