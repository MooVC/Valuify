namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Nested
{
    public static readonly Content CSharp2Body = new(
        """
                {
                    private T1 _age;
                    private T2 _name;

                    public T1 Age
                    {
                        get { return _age; }
                        set { _age = value; }
                    }
        
                    public T2 Name
                    {
                        get { return _name; }
                        set { _name = value; }
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
}