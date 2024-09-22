namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string SimpleContent = """
        namespace Valuify.Classes.Testing
        {
            [Valuify]
            public sealed partial class Simple
            {
                public int Age { get; }
        
                public bool IsAdult => Age >= 18;
        
                public string Name { get; }
            }
        }
        """;

    public static readonly Declared Simple;

    public static readonly Generated SimpleEquality = new(
        SimpleEqualityContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.Equality");

    public static readonly Generated SimpleEquals = new(
        SimpleEqualsContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.Equals");

    public static readonly Generated SimpleEquatableContract = new(
        SimpleEquatableContractContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.IEquatable");

    public static readonly Generated SimpleEquatableImplementation = new(
        SimpleEquatableImplementationContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.IEquatable.Equals");

    public static readonly Generated SimpleGetHashCode = new(
        SimpleGetHashCodeContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.GetHashCode");

    public static readonly Generated SimpleInequality = new(
        SimpleInequalityContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.Inequality");

    public static readonly Generated SimpleToString = new(
        SimpleToStringContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Simple.ToString");

    private const string SimpleEqualityContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
            {
                public static bool operator ==(Simple left, Simple right)
                {
                    return EqualityComparer<Simple>.Default.Equals(left, right);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleEqualsContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
            {
                public sealed override bool Equals(object other)
                {
                    return Equals(other as Simple);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleEquatableContractContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
                : IEquatable<Simple>
            {
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleEquatableImplementationContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
            {
                public bool Equals(Simple other)
                {
                    return EqualityComparer<Simple>.Default.Equals(this, other);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleGetHashCodeContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif
        
            partial class Simple
            {
                public sealed override int GetHashCode()
                {
                    return Valuify.Internal.HashCode.Combine(Age, IsAdult, Name);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleInequalityContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
            {
                public static bool operator !=(Simple left, Simple right)
                {
                    return !EqualityComparer<Simple>.Default.Equals(left, right);
                }
            }
        
            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string SimpleToStringContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Simple
            {
                public sealed override string ToString()
                {
                    return $"{nameof(Simple)} {{ {nameof(Age)} = {Age}, {nameof(IsAdult)} = {IsAdult}, {nameof(Name)} = {Name} }}";
                }
            }
        
            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;
}