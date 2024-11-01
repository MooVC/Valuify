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

            if (!(isPartial && current.IsSupported(out string declaration)))
            {
                return false;
            }

            var parent = new Nesting
            {
                Declaration = declaration,
                Name = current.Name,
                Qualification = current.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
            };

            nesting.Push(parent);
        }
        while (true);
    }

    private static string IdentifyPrefix(this INamedTypeSymbol symbol)
    {
        string @ref = symbol.IsRefLikeType
            ? "ref"
            : string.Empty;

        string @readonly = symbol.IsReadOnly
            ? "readonly"
            : string.Empty;

        return string
            .Join(" ", @readonly, @ref)
            .Trim();
    }

    private static string IdentifyType(this INamedTypeSymbol symbol)
    {
        return symbol.TypeKind switch
        {
            TypeKind.Class => symbol.IsRecord
                ? "record"
                : "class",
            TypeKind.Struct => symbol.IsRecord
                ? "record struct"
                : "struct",
            TypeKind.Interface => "interface",
            _ => string.Empty,
        };
    }

    private static bool IsSupported(this INamedTypeSymbol symbol, out string declaration)
    {
        string prefix = symbol.IdentifyPrefix();
        string type = symbol.IdentifyType();

        declaration = string
            .Join(" ", prefix, "partial", type)
            .TrimStart();

        return !string.IsNullOrEmpty(declaration);
    }
}