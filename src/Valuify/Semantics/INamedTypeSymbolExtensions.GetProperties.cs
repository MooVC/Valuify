namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Returns a collection of <see cref="Property"/> for each property belonging to <paramref name="class"/>.</summary>
    /// <param name="class">The class from which the properties are to be retrieved.</param>
    /// <returns>The collection of <see cref="Property"/> for each property belonging to <paramref name="class"/>.</returns>
    public static IReadOnlyList<Property> GetProperties(this INamedTypeSymbol @class)
    {
        return @class
            .GetAllProperties()
            .ToArray();
    }
}