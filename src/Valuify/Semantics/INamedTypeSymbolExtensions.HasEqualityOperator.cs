namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const string _equalityOperatorName = "op_Equality";

    /// <summary>
    /// Determines whether or not the <paramref name="class"/> declares an its own equals operator.
    /// </summary>
    /// <param name="class">
    /// The <paramref name="class"/> to be checked.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> declares the equals operator, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasEqualityOperator(this INamedTypeSymbol @class)
    {
        return @class.HasOperator(_equalityOperatorName);
    }
}