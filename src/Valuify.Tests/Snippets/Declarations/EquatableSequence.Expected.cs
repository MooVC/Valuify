namespace Valuify.Snippets.Declarations;

internal static partial class EquatableSequence
{
    public static class Expected
    {
        public static readonly Generated Equality = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class EquatableSequence
                    {
                        public static bool operator ==(EquatableSequence left, EquatableSequence right)
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
            "Valuify.Classes.Testing.EquatableSequence.Equality");

        public static new readonly Generated Equals = new(
            """
                namespace Valuify.Classes.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    partial class EquatableSequence
                    {
                        public override bool Equals(object other)
                        {
                            return Equals(other as EquatableSequence);
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
                    using System;
                    using System.Collections.Generic;

                    partial class EquatableSequence
                        : IEquatable<EquatableSequence>
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
                    using System;
                    using System.Collections.Generic;

                    partial class EquatableSequence
                    {
                        public bool Equals(EquatableSequence other)
                        {
                            if (ReferenceEquals(this, other))
                            {
                                return true;
                            }
                
                            if (ReferenceEquals(other, null))
                            {
                                return false;
                            }
                
                            return global::System.Collections.Generic.EqualityComparer<global::Valuify.Classes.Testing.EquatableCollection>.Default.Equals(Values, other.Values);
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
                    using System;
                    using System.Collections.Generic;
        
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
                    using System;
                    using System.Collections.Generic;

                    partial class EquatableSequence
                    {
                        public static bool operator !=(EquatableSequence left, EquatableSequence right)
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
                    using System;
                    using System.Collections.Generic;

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