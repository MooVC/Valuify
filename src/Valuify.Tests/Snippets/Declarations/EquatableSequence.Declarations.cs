namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class EquatableSequence
{
    public static class Declarations
    {
        public static readonly Content CSharp9Body = new(
            """
                {
                    public EquatableCollection Values { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                using System;
                using System.Collections.Generic;

                public sealed class EquatableCollection
                    : List<int>,
                      IEquatable<EquatableCollection>
                {
                    public bool Equals(EquatableCollection other)
                    {
                        return true;
                    }
                }

                [Valuify]
                public sealed partial class EquatableSequence
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}