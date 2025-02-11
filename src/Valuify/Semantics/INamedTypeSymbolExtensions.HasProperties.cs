namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Checks whether or not a <paramref name="class"/> has compatible properties.
    /// </summary>
    /// <param name="class">
    /// The class to check for compatible properties.
    /// </param>
    /// <param name="predicate">
    /// The predicate to apply to the properties.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="class"/> defines compatible properties, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasProperties(this INamedTypeSymbol @class, Func<Property, bool> predicate)
    {
        return @class
            .GetAllProperties()
            .Any(predicate);
    }
}