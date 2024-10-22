namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Nested
{
    public static partial class InInterface
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                """
                namespace Valuify.Classes.Testing
                {
                    public partial interface IOutter<T1>
                        where T1 : struct
                    {
                        [Valuify]
                        public sealed partial class Inner<T2>
                            where T2 : class
                __BODY__
                    }
                }
                """,
                LanguageVersion.CSharp8);
        }
    }
}