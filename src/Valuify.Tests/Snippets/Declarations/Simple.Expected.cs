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
                
                            return left.Equals(right);
                        }
                    }
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

                    partial class Simple
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as Simple);
                        }
                    }
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

                    partial class Simple
                        : IEquatable<Simple>
                    {
                    }
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

                    partial class Simple
                    {
                        public bool Equals(Simple other)
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
            "Valuify.Classes.Testing.Simple.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;
        
                    partial class Simple
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Age, IsAdult, Name);
                        }
                    }
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

                    partial class Simple
                    {
                        public static bool operator !=(Simple left, Simple right)
                        {
                            return !(left == right);
                        }
                    }
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

                    partial class Simple
                    {
                        public override string ToString()
                        {
                            return string.Format("Simple {{ Age = {0}, IsAdult = {1}, Name = {2} }}", Age, IsAdult, Name);
                        }
                    }
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Simple.ToString");
    }
}