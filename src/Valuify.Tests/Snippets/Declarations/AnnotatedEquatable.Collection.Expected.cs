namespace Valuify.Snippets.Declarations;

internal static partial class AnnotatedEquatable
{
    public static partial class Expected
    {
        public static class Collection
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

                        partial class AnnotatedEquatableCollection
                        {
                            public static bool operator ==(AnnotatedEquatableCollection left, AnnotatedEquatableCollection right)
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
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Equality");

            public static new readonly Generated Equals = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                        {
                            public override bool Equals(object other)
                            {
                                return Equals(other as AnnotatedEquatableCollection);
                            }
                        }

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable restore
                        #endif
                    }
                    """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Equals");

            public static readonly Generated EquatableContract = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                            : IEquatable<AnnotatedEquatableCollection>
                        {
                        }

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable restore
                        #endif
                    }
                    """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                        {
                            public bool Equals(AnnotatedEquatableCollection other)
                            {
                                if (ReferenceEquals(this, other))
                                {
                                    return true;
                                }

                                if (ReferenceEquals(other, null))
                                {
                                    return false;
                                }

                                return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(Capacity, other.Capacity)
                                    && global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(Count, other.Count);
                            }
                        }

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable restore
                        #endif
                    }
                    """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                        {
                            public override int GetHashCode()
                            {
                                return global::Valuify.Internal.HashCode.Combine(Capacity, Count);
                            }
                        }

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable restore
                        #endif
                    }
                    """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                        {
                            public static bool operator !=(AnnotatedEquatableCollection left, AnnotatedEquatableCollection right)
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
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Inequality");

            public static new readonly Generated ToString = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        using System;
                        using System.Collections.Generic;

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable disable
                        #endif

                        partial class AnnotatedEquatableCollection
                        {
                            public override string ToString()
                            {
                                return string.Format("AnnotatedEquatableCollection {{ Capacity = {0}, Count = {1} }}", Capacity, Count);
                            }
                        }

                        #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                        #nullable restore
                        #endif
                    }
                    """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.ToString");
        }
    }
}