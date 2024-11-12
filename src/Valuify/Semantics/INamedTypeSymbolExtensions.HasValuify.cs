namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="class"/> provided is annotated with the Valuify attribute.</summary>
    /// <param name="class">The symbol for the class to be checked for the presence of the Valuify attribute.</param>
    /// <returns>True if the Valuify attribute is present on the <paramref name="class"/>, otherwise False.</returns>
    public static bool HasValuify(this INamedTypeSymbol @class)
    {
        return @class
            .GetAttributes()
            .Select(attribute => new
            {
                Class = attribute.AttributeClass,
                Data = attribute,
            })
            .Any(attribute => attribute.Class is not null && attribute.Class.IsValuify());
    }
}