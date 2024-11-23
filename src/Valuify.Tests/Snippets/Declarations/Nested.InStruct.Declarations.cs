namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Nested
{
    public static partial class InStruct
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                """
                namespace Valuify.Classes.Testing
                {
                    public readonly ref partial struct Outter<T1>
                        where T1 : struct
                    {
                        [Valuify]
                        public sealed partial class Inner<T2>
                            where T2 : class
                __BODY__
                    }
                }
                """,
                LanguageVersion.CSharp7_2);
        }
    }
}