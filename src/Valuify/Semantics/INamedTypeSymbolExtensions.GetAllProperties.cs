namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private static IEnumerable<Property> GetAllProperties(this INamedTypeSymbol @class, Compilation compilation)
    {
        INamedTypeSymbol? current = @class;

        do
        {
            IEnumerable<IPropertySymbol> properties = current
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Where(property => !(property.IsStatic || property.IsIndexer)
                    && property.ExplicitInterfaceImplementations.Length == 0);

            foreach (var property in properties
                .Select(property => new { Symbol = property, Type = property.Type as INamedTypeSymbol })
                .Where(property => property.Type is not null))
            {
                yield return Parse(compilation, property.Symbol, property.Type!);
            }

            current = current.BaseType;
        }
        while (current is not null);
    }

    private static Property Parse(Compilation compilation, IPropertySymbol symbol, INamedTypeSymbol type)
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

        var property = new Property
        {
            IsEquatable = type.IsEquatable(compilation),
            IsImmutableArray = type.IsImmutableArray(compilation),
            IsIgnored = symbol.HasIgnore(),
            IsSequence = IsSequence(type),
            Name = symbol.Name,
            Type = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
        };

        if (!property.IsEquatable)
        {
            property.HasValuify = type.HasValuify(compilation);
        }

        return property;
    }
}