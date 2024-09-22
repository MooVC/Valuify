namespace Valuify.Snippets;

public static class Attributes
{
    public static readonly Generated Valuify = new(AttributeGenerator.Content, typeof(AttributeGenerator), "ValuifyAttribute");
}