namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string UnannotatedContent = """
        namespace Valuify.Classes.Testing
        {
            public sealed partial class Unannotated
            {
                public int Age { get; }
        
                public bool IsAdult => Age >= 18;
        
                public string Name { get; }
            }
        }
        """;

    public static readonly Declared Unannotated;
}