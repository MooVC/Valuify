namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string UnannotatedTemplate = """
        // CSharp1 is supported due to the absence of auto-properties

        namespace Valuify.Classes.Testing
        {
            public sealed class Unannotated
        __BODY__
        }
        """;

    public static readonly Declared Unannotated;
}