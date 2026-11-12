namespace Valuify.Snippets.Declarations;

internal static partial class Inherited
{
    public static partial class FromVirtual
    {
        public static class Expected
        {
            public static readonly Generated Equality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public static bool operator ==(global::Valuify.Classes.Testing.Inherited left, global::Valuify.Classes.Testing.Inherited right)
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
                "Valuify.Classes.Testing.Inherited.Equality");

            public static new readonly Generated Equals = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as global::Valuify.Classes.Testing.Inherited);
                        }
                    }
                }
                """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.Inherited.Equals");

            public static readonly Generated EquatableContract = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                        : global::System.IEquatable<global::Valuify.Classes.Testing.Inherited>
                    {
                    }
                }
                """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.Inherited.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public bool Equals(global::Valuify.Classes.Testing.Inherited other)
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
                "Valuify.Classes.Testing.Inherited.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Age, IsAdult, Name);
                        }
                    }
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.Inherited.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public static bool operator !=(global::Valuify.Classes.Testing.Inherited left, global::Valuify.Classes.Testing.Inherited right)
                        {
                            return !(left == right);
                        }
                    }
                }
                """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.Inherited.Inequality");

            public static new readonly Generated ToString = new(
                """
                namespace Valuify.Classes.Testing
                {
                    partial class Inherited
                    {
                        public override string ToString()
                        {
                            return string.Format("Inherited {{ Age = {0}, IsAdult = {1}, Name = {2} }}", Age, IsAdult, Name);
                        }
                    }
                }
                """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.Inherited.ToString");
        }
    }
}