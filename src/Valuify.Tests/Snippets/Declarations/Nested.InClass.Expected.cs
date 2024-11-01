﻿namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class InClass
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

                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public static bool operator ==(Inner<T2> left, Inner<T2> right)
                            {
                                return EqualityComparer<Inner<T2>>.Default.Equals(left, right);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperator,
                "Valuify.Classes.Testing.Outter.Inner.Equality");

            public static new readonly Generated Equals = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public sealed override bool Equals(object other)
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
                "Valuify.Classes.Testing.Outter.Inner.Equals");

            public static readonly Generated EquatableContract = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Outter<T1>
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
                "Valuify.Classes.Testing.Outter.Inner.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public bool Equals(Inner<T2> other)
                            {
                                return EqualityComparer<Inner<T2>>.Default.Equals(this, other);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.Outter.Inner.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public sealed override int GetHashCode()
                            {
                                return Valuify.Internal.HashCode.Combine(Age, Name);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.Outter.Inner.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public static bool operator !=(Inner<T2> left, Inner<T2> right)
                            {
                                return !EqualityComparer<Inner<T2>>.Default.Equals(left, right);
                            }
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.Outter.Inner.Inequality");

            public static new readonly Generated ToString = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public sealed override string ToString()
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
                "Valuify.Classes.Testing.Outter.Inner.ToString");
        }
    }
}