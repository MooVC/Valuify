namespace Valuify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Inherited
{
    public static readonly Content CSharp1Body = new(
            """
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
}