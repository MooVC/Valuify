namespace Valuify.Snippets.Declarations;

internal static partial class EquatableSequence
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public static bool operator ==(global::Valuify.Classes.Testing.EquatableSequence left, global::Valuify.Classes.Testing.EquatableSequence right)
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
            "Valuify.Classes.Testing.EquatableSequence.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as global::Valuify.Classes.Testing.EquatableSequence);
                        }
                    }
                }
                """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.EquatableSequence.Equals");

        public static readonly Generated EquatableContract = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                        : global::System.IEquatable<global::Valuify.Classes.Testing.EquatableSequence>
                    {
                    }
                }
                """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.EquatableSequence.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public bool Equals(global::Valuify.Classes.Testing.EquatableSequence other)
                        {
                            if (global::System.Object.ReferenceEquals(this, other))
                            {
                                return true;
                            }

                            if (global::System.Object.ReferenceEquals(other, null))
                            {
                                return false;
                            }

                            return global::System.Collections.Generic.EqualityComparer<global::Valuify.Classes.Testing.EquatableCollection>.Default.Equals(this.Values, other.Values);
                        }
                    }
                }
                """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.EquatableSequence.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public override int GetHashCode()
                        {
                            return global::Valuify.Internal.HashCode.Combine(global::Valuify.Internal.HashCode.GetHashCode(Values));
                        }
                    }
                }
                """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.EquatableSequence.GetHashCode");

        public static readonly Generated Inequality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public static bool operator !=(global::Valuify.Classes.Testing.EquatableSequence left, global::Valuify.Classes.Testing.EquatableSequence right)
                        {
                            return !(left == right);
                        }
                    }
                }
                """,
            Extensions.HasInequalityOperator,
            "Valuify.Classes.Testing.EquatableSequence.Inequality");

        public static new readonly Generated ToString = new(
            """
                namespace Valuify.Classes.Testing
                {
                    partial class EquatableSequence
                    {
                        public override string ToString()
                        {
                            return string.Format("EquatableSequence {{ Values = {0} }}", Values);
                        }
                    }
                }
                """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.EquatableSequence.ToString");
    }
}