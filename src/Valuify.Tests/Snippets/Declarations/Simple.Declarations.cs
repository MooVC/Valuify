namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Simple
{
    public static class Declarations
    {
        public static readonly Content CSharp1Body = new(
            """
                {
                    private int _age;
                    private string _name;

                    public int Age
                    {
                        get { return _age; }
                        set { _age = value; }
                    }
        
                    public bool IsAdult
                    {
                        get { return Age >= 18; }
                    }
        
                    public string Name
                    {
                        get { return _name; }
                        set { _name = value; }
                    }
                }
            """,
            LanguageVersion.CSharp1);

        public static readonly Content CSharp3Body = new(
            """
                {
                    public int Age { get; set; }
        
                    public bool IsAdult
                    {
                        get { return Age >= 18; }
                    }
        
                    public string Name { get; set; }
                }
            """,
            LanguageVersion.CSharp3);

        public static readonly Content CSharp6Body = new(
            """
                {
                    public int Age { get; }
        
                    public bool IsAdult => Age >= 18;
        
                    public string Name { get; }
                }
            """,
            LanguageVersion.CSharp6);

        public static readonly Content CSharp9Body = new(
            """
                {
                    public int Age { get; init; }
        
                    public bool IsAdult => Age >= 18;
        
                    public string Name { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Valuify.Classes.Testing
            {
                [Valuify]
                public sealed partial class Simple
            __BODY__
            }
            """,
            LanguageVersion.CSharp2);
    }
}