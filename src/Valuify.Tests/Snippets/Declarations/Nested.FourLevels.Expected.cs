namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class FourLevels
    {
        public static class Expected
        {
            public static readonly Generated Equality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public static bool operator ==(Fourth<T2> left, Fourth<T2> right)
                                    {
                                        if (ReferenceEquals(left, right))
                                        {
                                            return true;
                                        }

                                        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                                        {
                                            return false;
                                        }

                                        return left.Equals(right);
                                    }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperator,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.Equality");
        }
    }
}