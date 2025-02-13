namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Maps the required Semantics from the <paramref name="class"/> and places it within an instance of <see cref="Subject"/>.
    /// </summary>
    /// <param name="class">
    /// The subject from which the semantics are identified.
    /// </param>
    /// <param name="compilation">
    /// The <see cref="Compilation"/> used to source related symbol for semantic extraction.
    /// </param>
    /// <param name="nesting">
    /// The declaration syntax for the parents of the <paramref name="syntax"/>.
    /// </param>
    /// <returns>
    /// An instance of <see cref="Subject"/> containing the required semantics.
    /// </returns>
    public static Subject ToSubject(this INamedTypeSymbol @class, Compilation compilation, IReadOnlyList<Nesting> nesting)
    {
        string @namespace = @class.ContainingNamespace.IsGlobalNamespace
           ? string.Empty
           : @class.ContainingNamespace.ToDisplayString();

        return new Subject
        {
            CanOverrideEquals = @class.CanOverrideEquals(),
            CanOverrideGetHashCode = @class.CanOverrideGetHashCode(),
            CanOverrideToString = @class.CanOverrideToString(),
            HasEqualityOperator = @class.HasEqualityOperator(),
            HasEquatable = @class.HasEquatable(),
            HasInequalityOperator = @class.HasInequalityOperator(),
            IsEquatable = @class.IsEquatable(compilation),
            Name = @class.Name,
            Namespace = @namespace,
            Nesting = nesting,
            Properties = @class.GetProperties(),
            Qualification = @class.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
        };
    }
}