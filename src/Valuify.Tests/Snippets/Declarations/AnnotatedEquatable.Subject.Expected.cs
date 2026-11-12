namespace Valuify.Snippets.Declarations;

internal static partial class AnnotatedEquatable
{
    public static partial class Expected
    {
        public static class Subject
        {
            public static readonly Generated Equality = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public static bool operator ==(global::Valuify.Classes.Testing.AnnotatedEquatable left, global::Valuify.Classes.Testing.AnnotatedEquatable right)
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
                "Valuify.Classes.Testing.AnnotatedEquatable.Equality");

            public static new readonly Generated Equals = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public override bool Equals(object other)
                            {
                                return Equals(other as global::Valuify.Classes.Testing.AnnotatedEquatable);
                            }
                        }
                    }
                    """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.AnnotatedEquatable.Equals");

            public static readonly Generated EquatableContract = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                            : global::System.IEquatable<global::Valuify.Classes.Testing.AnnotatedEquatable>
                        {
                        }
                    }
                    """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatable.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public bool Equals(global::Valuify.Classes.Testing.AnnotatedEquatable other)
                            {
                                if (global::System.Object.ReferenceEquals(this, other))
                                {
                                    return true;
                                }

                                if (global::System.Object.ReferenceEquals(other, null))
                                {
                                    return false;
                                }

                                return global::System.Collections.Generic.EqualityComparer<global::Valuify.Classes.Testing.AnnotatedEquatableCollection>.Default.Equals(this.Values, other.Values);
                            }
                        }
                    }
                    """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatable.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public override int GetHashCode()
                            {
                                return global::Valuify.Internal.HashCode.Combine(global::Valuify.Internal.HashCode.GetHashCode(Values));
                            }
                        }
                    }
                    """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.AnnotatedEquatable.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public static bool operator !=(global::Valuify.Classes.Testing.AnnotatedEquatable left, global::Valuify.Classes.Testing.AnnotatedEquatable right)
                            {
                                return !(left == right);
                            }
                        }
                    }
                    """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.AnnotatedEquatable.Inequality");

            public static new readonly Generated ToString = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatable
                        {
                            public override string ToString()
                            {
                                return string.Format("AnnotatedEquatable {{ Values = {0} }}", Values);
                            }
                        }
                    }
                    """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.AnnotatedEquatable.ToString");
        }
    }
}