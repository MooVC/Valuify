namespace Valuify.Semantics;

using System.Data;
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
        static bool IsEnumerable(INamedTypeSymbol @interface)
        {
            return @interface.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                || @interface.SpecialType == SpecialType.System_Collections_IEnumerable;
        }

        static bool IsSequence(ITypeSymbol type)
        {
            return type.SpecialType != SpecialType.System_String && (type is IArrayTypeSymbol || type.AllInterfaces.Any(IsEnumerable));
        }

        return @class
            .GetMembers()
            .OfType<IPropertySymbol>()
            .Select(property => new Property
            {
                IsSequence = IsSequence(property.Type),
                Name = property.Name,
                Type = property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            })
            .ToArray();
    }
}