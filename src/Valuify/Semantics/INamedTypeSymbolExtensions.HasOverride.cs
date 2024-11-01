﻿namespace Valuify.Semantics;

using System.Collections.Immutable;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> declares an override for method denoted by <paramref name="name"/>.</summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <param name="name">The name of the method to locate.</param>
    /// <param name="predicate">Allows for the specification of an optional parameter check on the override method.</param>
    /// <param name="return">The return type for the method denoted by <paramref name="name"/>.</param>
    /// <returns>True if the <paramref name="class"/> overrides the method denoted by <paramref name="name"/>, otherwise False.</returns>
    /// <remarks>When no <paramref name="predicate"/> is specified, it is assumed that the method accepts no parameters.</remarks>
    public static bool HasOverride(
        this INamedTypeSymbol @class,
        string name,
        SpecialType @return,
        Predicate<ImmutableArray<IParameterSymbol>>? predicate = default)
    {
        predicate ??= parameters => parameters.Length == 0;

        return @class
            .GetMembers(name)
            .OfType<IMethodSymbol>()
            .Any(method => method.IsOverride
                        && method.ReturnType.SpecialType == @return
                        && SymbolEqualityComparer.Default.Equals(method.ContainingType, @class)
                        && predicate(method.Parameters));
    }
}