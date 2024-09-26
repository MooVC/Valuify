namespace Valuify.Snippets;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal static partial class Classes
{
    public const string GenericCSharp2Body = """
            {
                private T1 age;
                private T2 name;

                public T1 Age
                {
                    get { return age; }
                    set { age = value; }
                }
        
                public T2 Name
                {
                    get { return name; }
                    set { name = value; }
                }
            }
        """;

    public const string GenericCSharp3Body = """
            {
                public T1 Age { get; set; }
        
                public T2 Name { get; set; }
            }
        """;

    public const string GenericCSharp6Body = """
            {
                public T1 Age { get; }
        
                public T2 Name { get; }
            }
        """;

    public const string GenericCSharp9Body = """
            {
                public T1 Age { get; init; }
        
                public T2 Name { get; init; }
            }
        """;

    public const string StandardCSharp1Body = """
            {
                private int age;
                private string name;

                public int Age
                {
                    get { return age; }
                    set { age = value; }
                }
        
                public bool IsAdult
                {
                    get { return Age >= 18; }
                }
        
                public string Name
                {
                    get { return name; }
                    set { name = value; }
                }
            }
        """;

    public const string StandardCSharp3Body = """
            {
                public int Age { get; set; }
        
                public bool IsAdult
                {
                    get { return Age >= 18; }
                }
        
                public string Name { get; set; }
            }
        """;

    public const string StandardCSharp6Body = """
            {
                public int Age { get; }
        
                public bool IsAdult => Age >= 18;
        
                public string Name { get; }
            }
        """;

    public const string StandardCSharp9Body = """
            {
                public int Age { get; init; }
        
                public bool IsAdult => Age >= 18;
        
                public string Name { get; init; }
            }
        """;

    public static readonly Content[] Generic =
    [
        new(GenericCSharp2Body, LanguageVersion.CSharp2),
        new(GenericCSharp3Body, LanguageVersion.CSharp3),
        new(GenericCSharp6Body, LanguageVersion.CSharp6),
        new(GenericCSharp9Body, LanguageVersion.CSharp9),
    ];

    public static readonly Content[] Standard =
    [
        new(StandardCSharp1Body, LanguageVersion.CSharp1),
        new(StandardCSharp3Body, LanguageVersion.CSharp3),
        new(StandardCSharp6Body, LanguageVersion.CSharp6),
        new(StandardCSharp9Body, LanguageVersion.CSharp9),
    ];

    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "Needed due to order constraint.")]
    static Classes()
    {
        Generics = new(
            Generic,
            [
                GenericsEquality,
                GenericsEquals,
                GenericsEquatableContract,
                GenericsEquatableImplementation,
                GenericsGetHashCode,
                GenericsInequality,
                GenericsToString,
            ],
            nameof(Generics),
            new(GenericsTemplate, LanguageVersion.CSharp2));

        Simple = new(
            Standard,
            [
                SimpleEquality,
                SimpleEquals,
                SimpleEquatableContract,
                SimpleEquatableImplementation,
                SimpleGetHashCode,
                SimpleInequality,
                SimpleToString,
            ],
            nameof(Simple),
            new(SimpleTemplate, LanguageVersion.CSharp2));

        Unannotated = new(
            Standard,
            [],
            nameof(Unannotated),
            new(UnannotatedTemplate, LanguageVersion.CSharp2));

        Unsupported = new(
            Standard,
            [],
            nameof(Unsupported),
            new(UnsupportedTemplate, LanguageVersion.CSharp2));
    }
}