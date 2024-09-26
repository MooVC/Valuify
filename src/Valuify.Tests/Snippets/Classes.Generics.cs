namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string GenericsTemplate = """
        namespace Valuify.Classes.Testing
        {
            [Valuify]
            public sealed partial class Generics<T1, T2>
                where T1 : struct
                where T2 : class
        __BODY__
        }
        """;

    public static readonly Declared Generics;

    public static readonly Generated GenericsEquality = new(
        GenericsEqualityContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.Equality");

    public static readonly Generated GenericsEquals = new(
        GenericsEqualsContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.Equals");

    public static readonly Generated GenericsEquatableContract = new(
        GenericsEquatableContractContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.IEquatable");

    public static readonly Generated GenericsEquatableImplementation = new(
        GenericsEquatableImplementationContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.IEquatable.Equals");

    public static readonly Generated GenericsGetHashCode = new(
        GenericsGetHashCodeContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.GetHashCode");

    public static readonly Generated GenericsInequality = new(
        GenericsInequalityContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.Inequality");

    public static readonly Generated GenericsToString = new(
        GenericsToStringContent,
        typeof(ClassGenerator),
        "Valuify.Classes.Testing.Generics.ToString");

    private const string GenericsEqualityContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
            {
                public static bool operator ==(Generics<T1, T2> left, Generics<T1, T2> right)
                {
                    return EqualityComparer<Generics<T1, T2>>.Default.Equals(left, right);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsEqualsContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
            {
                public sealed override bool Equals(object other)
                {
                    return Equals(other as Generics<T1, T2>);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsEquatableContractContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
                : IEquatable<Generics<T1, T2>>
            {
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsEquatableImplementationContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
            {
                public bool Equals(Generics<T1, T2> other)
                {
                    return EqualityComparer<Generics<T1, T2>>.Default.Equals(this, other);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsGetHashCodeContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif
        
            partial class Generics<T1, T2>
            {
                public sealed override int GetHashCode()
                {
                    return Valuify.Internal.HashCode.Combine(Age, Name);
                }
            }

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsInequalityContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
            {
                public static bool operator !=(Generics<T1, T2> left, Generics<T1, T2> right)
                {
                    return !EqualityComparer<Generics<T1, T2>>.Default.Equals(left, right);
                }
            }
        
            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;

    private const string GenericsToStringContent = """
        namespace Valuify.Classes.Testing
        {
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            partial class Generics<T1, T2>
            {
                public sealed override string ToString()
                {
                    return string.Format("Generics { Age = {0}, Name = {1} }", Age, Name);
                }
            }
        
            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
        }
        """;
}