namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class InInterface
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

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public static bool operator ==(Inner<T2> left, Inner<T2> right)
                            {
                                if (ReferenceEquals(left, right))
                                {
                                    return true;
                                }
                
                                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                                {
                                    return false;
                                }
                
                                return global::System.Collections.Generic.EqualityComparer<T1>.Default.Equals(left.Age, right.Age)
                                    && global::System.Collections.Generic.EqualityComparer<T2>.Default.Equals(left.Name, right.Name);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperator,
                "Valuify.Classes.Testing.IOutter.Inner.Equality");

            public static new readonly Generated Equals = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override bool Equals(object other)
                            {
                                return Equals(other as Inner<T2>);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.IOutter.Inner.Equals");

            public static readonly Generated EquatableContract = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                            : IEquatable<Inner<T2>>
                        {
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.IOutter.Inner.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public bool Equals(Inner<T2> other)
                            {
                                return this == other;
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.IOutter.Inner.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override int GetHashCode()
                            {
                                return global::Valuify.Internal.HashCode.Combine(Age, Name);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.IOutter.Inner.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public static bool operator !=(Inner<T2> left, Inner<T2> right)
                            {
                                return !(left == right);
                            }
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.IOutter.Inner.Inequality");

            public static new readonly Generated ToString = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial interface IOutter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override string ToString()
                            {
                                return string.Format("Inner { Age = {0}, Name = {1} }", Age, Name);
                            }
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.IOutter.Inner.ToString");
        }
    }
}