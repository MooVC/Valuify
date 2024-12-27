namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Checks whether or not a <paramref name="class"/> has compatible properties.</summary>
    /// <param name="class">The class to check for compatible properties.</param>
    /// <returns>True if the <paramref name="class"/> defines compatible properties, otherwise false.</returns>
    public static bool HasProperties(this INamedTypeSymbol @class)
    {
        return @class
            .GetAllProperties()
            .Any();
    }
}