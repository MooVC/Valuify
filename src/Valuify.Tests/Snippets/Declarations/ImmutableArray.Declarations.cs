namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class ImmutableArray
{
    public static class Declarations
    {
        public static readonly Content CSharp9Body = new(
            """
                {
                    public ImmutableArray<int> Values { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                using System;
                using System.Collections.Immutable;

                [Valuify]
                public sealed partial class ImmutableArray
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}