namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Nested
{
    public static partial class FourLevels
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                """
                namespace Valuify.Classes.Testing
                {
                    public sealed partial class First<T1>
                        where T1 : struct
                    {
                        public sealed partial class Second
                        {
                            public sealed partial class Third
                            {
                                [Valuify]
                                public sealed partial class Fourth<T2>
                                    where T2 : class
                __BODY__
                            }
                        }
                    }
                }
                """,
                LanguageVersion.CSharp2);
        }
    }
}