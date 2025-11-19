namespace Valuify.Snippets.Declarations;

internal static partial class Explicit
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

                    partial class Explicit
                    {
                        public static bool operator ==(Explicit left, Explicit right)
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

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualityOperator,
            "Valuify.Classes.Testing.Explicit.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Explicit
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as Explicit);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.Explicit.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Explicit
                        : IEquatable<Explicit>
                    {
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.Explicit.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Explicit
                    {
                        public bool Equals(Explicit other)
                        {
                            if (ReferenceEquals(this, other))
                            {
                                return true;
                            }

                            return !ReferenceEquals(other, null)
                                && global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(Age, other.Age)
                                && global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(IsAdult, other.IsAdult)
                                && global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(Name, other.Name);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.Explicit.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial class Explicit
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
            "Valuify.Classes.Testing.Explicit.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Explicit
                    {
                        public static bool operator !=(Explicit left, Explicit right)
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
            "Valuify.Classes.Testing.Explicit.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Explicit
                    {
                        public override string ToString()
                        {
                            return string.Format("Explicit { Age = {0}, IsAdult = {1}, Name = {2} }", Age, IsAdult, Name);
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Explicit.ToString");
    }
}