namespace Valuify.Snippets.Declarations;

internal static partial class Inherited
{
    public static partial class FromSealed
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

                    partial class Inherited
                    {
                        public static bool operator ==(Inherited left, Inherited right)
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
                "Valuify.Classes.Testing.Inherited.Equality");

            public static readonly Generated EquatableContract = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Inherited
                        : IEquatable<Inherited>
                    {
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.Inherited.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Inherited
                    {
                        public bool Equals(Inherited other)
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
                "Valuify.Classes.Testing.Inherited.IEquatable.Equals");

            public static readonly Generated Inequality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Inherited
                    {
                        public static bool operator !=(Inherited left, Inherited right)
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
                "Valuify.Classes.Testing.Inherited.Inequality");
        }
    }
}