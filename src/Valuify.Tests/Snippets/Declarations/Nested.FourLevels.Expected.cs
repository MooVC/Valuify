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
                }
                """,
                Extensions.HasEqualityOperator,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.Equality");

            public static new readonly Generated Equals = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public override bool Equals(object other)
                                    {
                                        return Equals(other as Fourth<T2>);
                                    }
                                }
                            }
                        }
                    }
                }
                """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.Equals");

            public static readonly Generated EquatableContract = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                    : IEquatable<Fourth<T2>>
                                {
                                }
                            }
                        }
                    }
                }
                """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public bool Equals(Fourth<T2> other)
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
                    }
                }
                """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public override int GetHashCode()
                                    {
                                        return global::Valuify.Internal.HashCode.Combine(Age, Name);
                                    }
                                }
                            }
                        }
                    }
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public static bool operator !=(Fourth<T2> left, Fourth<T2> right)
                                    {
                                        return !(left == right);
                                    }
                                }
                            }
                        }
                    }
                }
                """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.Inequality");

            public static new readonly Generated ToString = new(
                """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class First<T1>
                    {
                        partial class Second
                        {
                            partial class Third
                            {
                                partial class Fourth<T2>
                                {
                                    public override string ToString()
                                    {
                                        return string.Format("Fourth {{ Age = {0}, Name = {1} }}", Age, Name);
                                    }
                                }
                            }
                        }
                    }
                }
                """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.First.Second.Third.Fourth.ToString");
        }
    }
}