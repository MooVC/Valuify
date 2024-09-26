namespace Valuify.Snippets;

internal static partial class Classes
{
    public const string UnsupportedTemplate = """
        // CSharp6 is needed due to the read-only auto-properties

        namespace Valuify.Classes.Testing
        {
            [Valuify]
            public sealed class Unsupported
        __BODY__
        }
        """;

    public static readonly Declared Unsupported;
}