namespace Valuify.Snippets.Declarations;

internal static partial class ImmutableArray
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

                    partial class ImmutableArray
                    {
                        public static bool operator ==(ImmutableArray left, ImmutableArray right)
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
            "Valuify.Classes.Testing.ImmutableArray.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class ImmutableArray
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as ImmutableArray);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.ImmutableArray.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class ImmutableArray
                        : IEquatable<ImmutableArray>
                    {
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.ImmutableArray.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class ImmutableArray
                    {
                        public bool Equals(ImmutableArray other)
                        {
                            if (ReferenceEquals(this, other))
                            {
                                return true;
                            }
                
                            if (ReferenceEquals(other, null))
                            {
                                return false;
                            }
                
                            return global::Valuify.Internal.SequenceEqualityComparer.Default.Equals(Values, other.Values);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.ImmutableArray.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial class ImmutableArray
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Values);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.ImmutableArray.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class ImmutableArray
                    {
                        public static bool operator !=(ImmutableArray left, ImmutableArray right)
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
            "Valuify.Classes.Testing.ImmutableArray.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class ImmutableArray
                    {
                        public override string ToString()
                        {
                            return string.Format("ImmutableArray {{ Values = {0} }}", Values);
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.ImmutableArray.ToString");
    }
}