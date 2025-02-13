namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static class Redundant
{
    public static readonly Snippets Declaration = new(
        Simple.Declaration.Body,
        new(
            """
            namespace Valuify.Records.Testing
            {
                [Valuify]
                public sealed partial record Redundant
            __BODY__
            }
            """,
            LanguageVersion.CSharp9),
        [],
        [],
        nameof(Redundant));
}