namespace Valuify.Snippets.Declarations;

internal static partial class Ignored
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                    {
                        public static bool operator ==(Ignored left, Ignored right)
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
                """,
            Extensions.HasEqualityOperator,
            "Valuify.Classes.Testing.Ignored.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as Ignored);
                        }
                    }
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.Ignored.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                        : IEquatable<Ignored>
                    {
                    }
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.Ignored.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                    {
                        public bool Equals(Ignored other)
                        {
                            if (ReferenceEquals(this, other))
                            {
                                return true;
                            }
                
                            if (ReferenceEquals(other, null))
                            {
                                return false;
                            }
                
                            return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(Age, other.Age)
                                && global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(IsAdult, other.IsAdult);
                        }
                    }
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.Ignored.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;
        
                    partial class Ignored
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Age, IsAdult);
                        }
                    }
                }
                """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.Ignored.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                    {
                        public static bool operator !=(Ignored left, Ignored right)
                        {
                            return !(left == right);
                        }
                    }
                }
                """,
            Extensions.HasInequalityOperator,
            "Valuify.Classes.Testing.Ignored.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class Ignored
                    {
                        public override string ToString()
                        {
                            return string.Format("Ignored {{ Age = {0}, IsAdult = {1} }}", Age, IsAdult);
                        }
                    }
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Ignored.ToString");
    }
}