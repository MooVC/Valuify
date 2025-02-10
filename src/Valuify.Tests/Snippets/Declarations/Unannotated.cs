namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static class Unannotated
{
    public static readonly Snippets Declaration = new(
        Ignored.Declaration.Body,
        new(
            """
            namespace Valuify.Classes.Testing
            {
                public sealed class Unannotated
            __BODY__
            }
            """,
            LanguageVersion.CSharp2),
        [],
        [],
        nameof(Unannotated));
}