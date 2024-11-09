namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Generics
{
    public static class Declarations
    {
        public static readonly Content CSharp2Body = new(
            """
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
            """,
            LanguageVersion.CSharp2);

        public static readonly Content CSharp3Body = new(
            """
                {
                    public T1 Age { get; set; }
        
                    public T2 Name { get; set; }
                }
            """,
            LanguageVersion.CSharp3);

        public static readonly Content CSharp6Body = new(
            """
                {
                    public T1 Age { get; }
        
                    public T2 Name { get; }
                }
            """,
            LanguageVersion.CSharp6);

        public static readonly Content CSharp9Body = new(
            """
                {
                    public T1 Age { get; init; }
        
                    public T2 Name { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                [Valuify]
                public sealed partial class Generics<T1, T2>
                    where T1 : struct
                    where T2 : class
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}