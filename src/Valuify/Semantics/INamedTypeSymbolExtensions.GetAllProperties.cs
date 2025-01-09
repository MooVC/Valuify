namespace Valuify.Semantics;

using Microsoft.CodeAnalysis;
using Valuify.Model;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    private static IEnumerable<Property> GetAllProperties(this INamedTypeSymbol @class)
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

        INamedTypeSymbol? current = @class;

        do
        {
            IEnumerable<IPropertySymbol> properties = current
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Where(property => property.ExplicitInterfaceImplementations.Length == 0);

            foreach (IPropertySymbol property in properties)
            {
                yield return new Property
                {
                    IsSequence = IsSequence(property.Type),
                    Name = property.Name,
                    Type = property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                };
            }

            current = current.BaseType;
        }
        while (current is not null);
    }
}