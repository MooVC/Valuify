namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string UnsupportedContent = """
        namespace Valuify.Classes.Testing
        {
            [Valuify]
            public sealed class Unsupported
            {
                public int Age { get; }

                public bool IsAdult => Age >= 18;

                public string Name { get; }
            }
        }
        """;

    public static readonly Declared Unsupported;
}