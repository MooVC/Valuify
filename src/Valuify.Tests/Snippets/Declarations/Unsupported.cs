namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static class Unsupported
{
    public static readonly Snippets Declaration = new(
        Simple.Declaration.Body,
        new(
            """
            namespace Valuify.Classes.Testing
            {
                [Valuify]
                public sealed class Unsupported
            __BODY__
            }
            """,
            LanguageVersion.CSharp2),
        [],
        [],
        nameof(Unsupported));
}