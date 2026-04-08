namespace Valuify.Snippets.Declarations;

internal static partial class AnnotatedEquatable
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

                    partial class AnnotatedEquatable
                    {
                        public static bool operator ==(AnnotatedEquatable left, AnnotatedEquatable right)
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
            "Valuify.Classes.Testing.AnnotatedEquatable.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class AnnotatedEquatable
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as AnnotatedEquatable);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.AnnotatedEquatable.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class AnnotatedEquatable
                        : IEquatable<AnnotatedEquatable>
                    {
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.AnnotatedEquatable.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class AnnotatedEquatable
                    {
                        public bool Equals(AnnotatedEquatable other)
                        {
                            if (ReferenceEquals(this, other))
                            {
                                return true;
                            }
                
                            if (ReferenceEquals(other, null))
                            {
                                return false;
                            }
                
                            return global::System.Collections.Generic.EqualityComparer<global::Valuify.Classes.Testing.AnnotatedEquatableCollection>.Default.Equals(Values, other.Values);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.AnnotatedEquatable.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif
        
                    partial class AnnotatedEquatable
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
            "Valuify.Classes.Testing.AnnotatedEquatable.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class AnnotatedEquatable
                    {
                        public static bool operator !=(AnnotatedEquatable left, AnnotatedEquatable right)
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
            "Valuify.Classes.Testing.AnnotatedEquatable.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class AnnotatedEquatable
                    {
                        public override string ToString()
                        {
                            return string.Format("AnnotatedEquatable {{ Values = {0} }}", Values);
                        }
                    }
        
                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.AnnotatedEquatable.ToString");
    }
}