namespace Valuify.Snippets.Declarations;

internal static partial class Simple
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

                    partial class Simple
                    {
                        public static bool operator ==(Simple left, Simple right)
                        {
                            if (ReferenceEquals(left, right))
                            {
                                return true;
                            }
                
                            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                            {
                                return false;
                            }
                
                            return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(left.Age, right.Age)
                                && global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(left.IsAdult, right.IsAdult)
                                && global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(left.Name, right.Name);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualityOperator,
            "Valuify.Classes.Testing.Simple.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as Simple);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.Simple.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                        : IEquatable<Simple>
                    {
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.Simple.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public bool Equals(Simple other)
                        {
                            return this == other;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.Simple.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial class Simple
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Age, IsAdult, Name);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.Simple.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static bool operator !=(Simple left, Simple right)
                        {
                            return !(left == right);
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasInequalityOperator,
            "Valuify.Classes.Testing.Simple.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public override string ToString()
                        {
                            return string.Format("Simple { Age = {0}, IsAdult = {1}, Name = {2} }", Age, IsAdult, Name);
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Simple.ToString");
    }
}