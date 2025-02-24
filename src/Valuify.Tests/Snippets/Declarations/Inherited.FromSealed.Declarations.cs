namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Inherited
{
    public static partial class FromSealed
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                """
                namespace Valuify.Classes.Testing
                {
                    public class Base
                    {
                        public sealed override bool Equals(object other)
                        {
                            return false;
                        }

                        public sealed override int GetHashCode()
                        {
                            return 0;
                        }

                        public sealed override string ToString()
                        {
                            return "Sealed";
                        }
                    }

                    [Valuify]
                    public sealed partial class Inherited
                        : Base
                __BODY__
                }
                """,
                LanguageVersion.CSharp11);
        }
    }
}