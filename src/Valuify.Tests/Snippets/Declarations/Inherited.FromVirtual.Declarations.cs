namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Inherited
{
    public static partial class FromVirtual
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                """
                namespace Valuify.Classes.Testing
                {
                    public class Base
                __BODY__

                    [Valuify]
                    public sealed partial class Inherited
                        : Base
                    {
                    }
                }
                """,
                LanguageVersion.CSharp2);
        }
    }
}