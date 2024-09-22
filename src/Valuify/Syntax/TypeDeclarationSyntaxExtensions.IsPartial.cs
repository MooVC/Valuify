namespace Valuify.Syntax;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>Provides extensions relating to <see cref="TypeDeclarationSyntax"/>.</summary>
internal static partial class TypeDeclarationSyntaxExtensions
{
    /// <summary>Determines whether or not the <paramref name="syntax"/> provided is annotated with the partial keyword.</summary>
    /// <param name="syntax">The symbol for the type to be checked for the presence of the partial keyword.</param>
    /// <param name="nesting">The declaration syntax for the parents of the <paramref name="syntax"/>.</param>
    /// <returns>True if the partial keyword is present on the <paramref name="syntax"/>, otherwise False.</returns>
    public static bool IsPartial(this TypeDeclarationSyntax syntax, Stack<string> nesting)
    {
        if (syntax.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword)))
        {
            var parent = syntax.Parent as TypeDeclarationSyntax;

            if (parent is not null)
            {
                nesting.Push(parent.ToFullString());

                return parent.IsPartial(nesting);
            }

            return true;
        }

        return false;
    }
}