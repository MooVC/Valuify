namespace Valuify.Snippets.Declarations;

internal static partial class AnnotatedEquatable
{
    public static partial class Expected
    {
        public static class Collection
        {
            public static readonly Generated Equality = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public static bool operator ==(global::Valuify.Classes.Testing.AnnotatedEquatableCollection left, global::Valuify.Classes.Testing.AnnotatedEquatableCollection right)
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
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Equality");

            public static new readonly Generated Equals = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public override bool Equals(object other)
                            {
                                return Equals(other as global::Valuify.Classes.Testing.AnnotatedEquatableCollection);
                            }
                        }
                    }
                    """,
                Extensions.HasEqualsOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Equals");

            public static readonly Generated EquatableContract = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                            : global::System.IEquatable<global::Valuify.Classes.Testing.AnnotatedEquatableCollection>
                        {
                        }
                    }
                    """,
                Extensions.IsEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.IEquatable");

            public static readonly Generated EquatableImplementation = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public bool Equals(global::Valuify.Classes.Testing.AnnotatedEquatableCollection other)
                            {
                                if (global::System.Object.ReferenceEquals(this, other))
                                {
                                    return true;
                                }

                                if (global::System.Object.ReferenceEquals(other, null))
                                {
                                    return false;
                                }

                                return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(this.Capacity, other.Capacity)
                                    && global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(this.Count, other.Count);
                            }
                        }
                    }
                    """,
                Extensions.HasEquatable,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.IEquatable.Equals");

            public static new readonly Generated GetHashCode = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public override int GetHashCode()
                            {
                                return global::Valuify.Internal.HashCode.Combine(Capacity, Count);
                            }
                        }
                    }
                    """,
                Extensions.HasGetHashCodeOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.GetHashCode");

            public static readonly Generated Inequality = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public static bool operator !=(global::Valuify.Classes.Testing.AnnotatedEquatableCollection left, global::Valuify.Classes.Testing.AnnotatedEquatableCollection right)
                            {
                                return !(left == right);
                            }
                        }
                    }
                    """,
                Extensions.HasInequalityOperator,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.Inequality");

            public static new readonly Generated ToString = new(
                """
                    namespace Valuify.Classes.Testing
                    {
                        partial class AnnotatedEquatableCollection
                        {
                            public override string ToString()
                            {
                                return string.Format("AnnotatedEquatableCollection {{ Capacity = {0}, Count = {1} }}", Capacity, Count);
                            }
                        }
                    }
                    """,
                Extensions.HasToStringOverride,
                "Valuify.Classes.Testing.AnnotatedEquatableCollection.ToString");
        }
    }
}