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

                    partial class Explicit
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as Explicit);
                        }
                    }
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

                    partial class Explicit
                        : IEquatable<Explicit>
                    {
                    }
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

                    partial class Explicit
                    {
                        public bool Equals(Explicit other)
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
                                && global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(IsAdult, other.IsAdult)
                                && global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(Name, other.Name);
                        }
                    }
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
        
                    partial class Explicit
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Age, IsAdult, Name);
                        }
                    }
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

                    partial class Explicit
                    {
                        public static bool operator !=(Explicit left, Explicit right)
                        {
                            return !(left == right);
                        }
                    }
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

                    partial class Explicit
                    {
                        public override string ToString()
                        {
                            return string.Format("Explicit {{ Age = {0}, IsAdult = {1}, Name = {2} }}", Age, IsAdult, Name);
                        }
                    }
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Explicit.ToString");
    }
}