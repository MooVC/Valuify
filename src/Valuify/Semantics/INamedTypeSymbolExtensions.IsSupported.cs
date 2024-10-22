namespace Valuify.Semantics;

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Valuify.Model;
using Valuify.Syntax;

/// <summary>Provides extensions relating to <see cref="INamedTypeSymbol"/>.</summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>Determines whether or not the <paramref name="symbol"/> provided is supported by Valuify.</summary>
    /// <param name="symbol">The symbol for the type to be checked for Valuify support.</param>
    /// <param name="nesting">The declaration syntax for the parents of the <paramref name="syntax"/>.</param>
    /// <returns>True if the type is annotated and partial, otherwise False.</returns>
    public static bool IsSupported(this INamedTypeSymbol symbol, Stack<Nesting> nesting)
    {
        if (!symbol.HasValuify())
        {
            return false;
        }

        INamedTypeSymbol? current = symbol;

        do
        {
            current = current.ContainingType;

            if (current is null)
            {
                return true;
            }

            bool isPartial = current.DeclaringSyntaxReferences
                .OfType<TypeDeclarationSyntax>()
                .All(type => type.IsPartial());

            if (!(isPartial && current.IsSupported(out string type)))
            {
                return false;
            }

            var parent = new Nesting
            {
                Name = current.Name,
                Qualification = current.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                Type = type,
            };

            nesting.Push(parent);
        }
        while (true);
    }

    private static string IdentifyType(this INamedTypeSymbol symbol)
    {
        switch (symbol.TypeKind)
        {
            case TypeKind.Class:

                if (symbol.IsRecord)
                {
                    return symbol.IsValueType
                        ? "record struct"
                        : "record";
                }

                return "class";

            case TypeKind.Struct:
                return "struct";

            case TypeKind.Interface:
                return "interface";

            default:
                return string.Empty;
        }
    }

    private static bool IsSupported(this INamedTypeSymbol symbol, out string type)
    {
        type = symbol.IdentifyType();

        return !string.IsNullOrEmpty(type);
    }
}