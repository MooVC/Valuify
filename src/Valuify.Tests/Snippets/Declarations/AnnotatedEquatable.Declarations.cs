namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class AnnotatedEquatable
{
    public static class Declarations
    {
        public static readonly Content CSharp9Body = new(
            """
                {
                    public AnnotatedEquatableCollection Values { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                using System.Collections.Generic;

                [Valuify]
                public sealed class AnnotatedEquatableCollection
                    : List<int>
                {
                }

                [Valuify]
                public sealed partial class AnnotatedEquatable
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}