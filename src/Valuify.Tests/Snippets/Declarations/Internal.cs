namespace Valuify.Snippets.Declarations;

public static class Internal
{
    public static readonly Generated HashCode = new(
        HashCodeGenerator.Content,
        Extensions.None,
        "Valuify.Internal.HashCode",
        Generator: typeof(HashCodeGenerator));
}