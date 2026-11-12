namespace Valuify.Snippets.Declarations;

internal static partial class Simple
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class Simple
                    {
                        public static bool operator ==(global::Valuify.Classes.Testing.Simple left, global::Valuify.Classes.Testing.Simple right)
                        {
                            if (global::System.Object.ReferenceEquals(left, right))
                            {
                                return true;
                            }

                            if (global::System.Object.ReferenceEquals(left, null) || global::System.Object.ReferenceEquals(right, null))
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
                    partial class Simple
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as global::Valuify.Classes.Testing.Simple);
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
                    partial class Simple
                        : global::System.IEquatable<global::Valuify.Classes.Testing.Simple>
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
                    partial class Simple
                    {
                        public bool Equals(global::Valuify.Classes.Testing.Simple other)
                        {
                            if (global::System.Object.ReferenceEquals(this, other))
                            {
                                return true;
                            }

                            if (global::System.Object.ReferenceEquals(other, null))
                            {
                                return false;
                            }

                            return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(this.Age, other.Age)
                                && global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(this.IsAdult, other.IsAdult)
                                && global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(this.Name, other.Name);
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
                    partial class Simple
                    {
                        public static bool operator !=(global::Valuify.Classes.Testing.Simple left, global::Valuify.Classes.Testing.Simple right)
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