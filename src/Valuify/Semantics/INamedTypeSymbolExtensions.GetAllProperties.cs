namespace Valuify.Semantics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Valuify.Model;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        private static IEnumerable<Property> GetAllProperties(this INamedTypeSymbol @class, Compilation compilation)
        {
            INamedTypeSymbol current = @class;

            do
            {
                IEnumerable<IPropertySymbol> properties = current
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Where(property => !(property.IsStatic || property.IsIndexer)
                        && property.ExplicitInterfaceImplementations.Length == 0)
                    .Distinct(PropertyNameEqualityComparer.Instance);

                foreach (IPropertySymbol property in properties)
                {
                    yield return Parse(compilation, property);
                }

                current = current.BaseType;
            }
            while (!(current is null));
        }

        private static Property Parse(Compilation compilation, IPropertySymbol symbol)
        {
            bool IsEnumerable(INamedTypeSymbol @interface)
            {
                return @interface.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                    || @interface.SpecialType == SpecialType.System_Collections_IEnumerable;
            }

            bool IsSequence(ITypeSymbol type)
            {
                return type.SpecialType != SpecialType.System_String && (type is IArrayTypeSymbol || type.AllInterfaces.Any(IsEnumerable));
            }

            var property = new Property
            {
                IsIgnored = symbol.HasIgnore(),
                IsSequence = IsSequence(symbol.Type),
                Name = symbol.Name,
                Type = symbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            };

            if (!(symbol.Type is INamedTypeSymbol named))
            {
                return property;
            }

            property.IsEquatable = named.IsEquatable(compilation);
            property.IsImmutableArray = named.IsImmutableArray(compilation);

            if (!property.IsEquatable)
            {
                property.HasValuify = named.HasValuify(compilation);
            }

            return property;
        }
    }
}