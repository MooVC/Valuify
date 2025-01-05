namespace Valuify.Semantics;

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="class"/> inherits a sealed override for the method denoted by <paramref name="name"/>.
    /// </summary>
    /// <param name="class">The <paramref name="class"/> to be checked.</param>
    /// <param name="name">The name of the method to locate.</param>
    /// <param name="predicate">Allows for the specification of an optional parameter check on the override method.</param>
    /// <param name="return">The return type for the method denoted by <paramref name="name"/>.</param>
    /// <returns>True if the <paramref name="class"/> inherits a sealed override to the method denoted by <paramref name="name"/>, otherwise False.</returns>
    /// <remarks>When no <paramref name="predicate"/> is specified, it is assumed that the method accepts no parameters.</remarks>
    public static bool InheritsSealed(
        this INamedTypeSymbol @class,
        string name,
        SpecialType @return,
        Predicate<IMethodSymbol>? predicate = default)
    {
        predicate ??= method => method.Parameters.Length == 0;

        for (INamedTypeSymbol? @base = @class.BaseType; @base is not null && @base.SpecialType != SpecialType.System_Object; @base = @base.BaseType)
        {
            bool InheritsSealed(IMethodSymbol method)
            {
                return method.IsSealed && predicate(method);
            }

            if (@base.HasOverride(name, @return, InheritsSealed))
            {
                return true;
            }
        }

        return false;
    }
}