namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class InStruct
    {
        public static class Expected
        {
            public static readonly Generated Equality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    readonly ref partial struct Outter<T1>
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
                
                                return left.Equals(right);
                            }
                        }
                    }
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

                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override bool Equals(object other)
                            {
                                return Equals(other as Inner<T2>);
                            }
                        }
                    }
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

                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                            : IEquatable<Inner<T2>>
                        {
                        }
                    }
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

                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public bool Equals(Inner<T2> other)
                            {
                                if (ReferenceEquals(this, other))
                                {
                                    return true;
                                }
                
                                if (ReferenceEquals(other, null))
                                {
                                    return false;
                                }
                
                                return global::System.Collections.Generic.EqualityComparer<T1>.Default.Equals(Age, other.Age)
                                    && global::System.Collections.Generic.EqualityComparer<T2>.Default.Equals(Name, other.Name);
                            }
                        }
                    }
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
        
                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override int GetHashCode()
                            {
                                return global::Valuify.Internal.HashCode.Combine(Age, Name);
                            }
                        }
                    }
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

                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public static bool operator !=(Inner<T2> left, Inner<T2> right)
                            {
                                return !(left == right);
                            }
                        }
                    }
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

                    readonly ref partial struct Outter<T1>
                    {
                        partial class Inner<T2>
                        {
                            public override string ToString()
                            {
                                return string.Format("Inner {{ Age = {0}, Name = {1} }}", Age, Name);
                            }
                        }
                    }
                }
                """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.Outter.Inner.ToString");
        }
    }
}