namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Maps the required Semantics from the <paramref name="class"/> and places it within an instance of <see cref="Subject"/>.</summary>
    /// <param name="class">The subject from which the semantics are identified.</param>
    /// <param name="compilation">The <see cref="Compilation"/> used to source related symbol for semantic extraction.</param>
    /// <param name="nesting">The declaration syntax for the parents of the <paramref name="syntax"/>.</param>
    /// <returns>An instance of <see cref="Subject"/> containing the required semantics.</returns>
    public static Subject ToSubject(this INamedTypeSymbol @class, Compilation compilation, IReadOnlyList<Nesting> nesting)
    {
        string @namespace = @class.ContainingNamespace.IsGlobalNamespace
           ? string.Empty
           : @class.ContainingNamespace.ToDisplayString();

        return new Subject
        {
            HasEqualityOperator = @class.HasEqualityOperator(),
            HasEquatable = @class.HasEquatable(),
            HasEqualsOverride = @class.HasEqualsOverride(),
            HasGetHashCodeOverride = @class.HasGetHashCodeOverride(),
            HasInequalityOperator = @class.HasInequalityOperator(),
            HasToStringOverride = @class.HasToStringOverride(),
            IsEquatable = @class.IsEquatable(compilation),
            Name = @class.Name,
            Namespace = @namespace,
            Nesting = nesting,
            Properties = @class.GetProperties(),
            Qualification = @class.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
        };
    }
}