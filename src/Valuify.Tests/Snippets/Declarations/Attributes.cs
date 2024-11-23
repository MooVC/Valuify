namespace Valuify.Snippets.Declarations;

public static class Attributes
{
    public static readonly Generated Valuify = new(
        AttributeGenerator.Content,
        Extensions.None,
        "ValuifyAttribute",
        typeof(AttributeGenerator));
}