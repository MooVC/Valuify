namespace Valuify.Snippets.Declarations;

internal static partial class ImmutableArray
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public static bool operator ==(global::Valuify.Classes.Testing.ImmutableArray left, global::Valuify.Classes.Testing.ImmutableArray right)
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
            "Valuify.Classes.Testing.ImmutableArray.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as global::Valuify.Classes.Testing.ImmutableArray);
                        }
                    }
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.ImmutableArray.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                        : global::System.IEquatable<global::Valuify.Classes.Testing.ImmutableArray>
                    {
                    }
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.ImmutableArray.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public bool Equals(global::Valuify.Classes.Testing.ImmutableArray other)
                        {
                            if (global::System.Object.ReferenceEquals(this, other))
                            {
                                return true;
                            }

                            if (global::System.Object.ReferenceEquals(other, null))
                            {
                                return false;
                            }

                            return global::Valuify.Internal.SequenceEqualityComparer.Default.Equals(this.Values, other.Values);
                        }
                    }
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.ImmutableArray.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(Values);
                        }
                    }
                }
                """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.ImmutableArray.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public static bool operator !=(global::Valuify.Classes.Testing.ImmutableArray left, global::Valuify.Classes.Testing.ImmutableArray right)
                        {
                            return !(left == right);
                        }
                    }
                }
                """,
            Extensions.HasInequalityOperator,
            "Valuify.Classes.Testing.ImmutableArray.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class ImmutableArray
                    {
                        public override string ToString()
                        {
                            return string.Format("ImmutableArray {{ Values = {0} }}", Values);
                        }
                    }
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.ImmutableArray.ToString");
    }
}