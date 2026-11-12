namespace Valuify.Snippets.Declarations;

internal static partial class Generics
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public static bool operator ==(global::Valuify.Classes.Testing.Generics<T1, T2> left, global::Valuify.Classes.Testing.Generics<T1, T2> right)
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
            "Valuify.Classes.Testing.Generics.Equality");

        public static new readonly Generated Equals = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public override bool Equals(object other)
                    {
                        return Equals(other as global::Valuify.Classes.Testing.Generics<T1, T2>);
                    }
                }
            }
            """,
            Extensions.HasEqualsOverride,
            "Valuify.Classes.Testing.Generics.Equals");

        public static readonly Generated EquatableContract = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                    : global::System.IEquatable<global::Valuify.Classes.Testing.Generics<T1, T2>>
                {
                }
            }
            """,
            Extensions.IsEquatable,
            "Valuify.Classes.Testing.Generics.IEquatable");

        public static readonly Generated EquatableImplementation = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public bool Equals(global::Valuify.Classes.Testing.Generics<T1, T2> other)
                    {
                        if (global::System.Object.ReferenceEquals(this, other))
                        {
                            return true;
                        }

                        if (global::System.Object.ReferenceEquals(other, null))
                        {
                            return false;
                        }

                        return global::System.Collections.Generic.EqualityComparer<T1>.Default.Equals(this.Age, other.Age)
                            && global::System.Collections.Generic.EqualityComparer<T2>.Default.Equals(this.Name, other.Name);
                    }
                }
            }
            """,
            Extensions.HasEquatable,
            "Valuify.Classes.Testing.Generics.IEquatable.Equals");

        public static new readonly Generated GetHashCode = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public override int GetHashCode()
                    {
                        return global::Valuify.Internal.HashCode.Combine(Age, Name);
                    }
                }
            }
            """,
            Extensions.HasGetHashCodeOverride,
            "Valuify.Classes.Testing.Generics.GetHashCode");

        public static readonly Generated Inequality = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public static bool operator !=(global::Valuify.Classes.Testing.Generics<T1, T2> left, global::Valuify.Classes.Testing.Generics<T1, T2> right)
                    {
                        return !(left == right);
                    }
                }
            }
            """,
            Extensions.HasInequalityOperator,
            "Valuify.Classes.Testing.Generics.Inequality");

        public static new readonly Generated ToString = new(
            """
            namespace Valuify.Classes.Testing
            {
                partial class Generics<T1, T2>
                {
                    public override string ToString()
                    {
                        return string.Format("Generics {{ Age = {0}, Name = {1} }}", Age, Name);
                    }
                }
            }
            """,
            Extensions.HasToStringOverride,
            "Valuify.Classes.Testing.Generics.ToString");
    }
}