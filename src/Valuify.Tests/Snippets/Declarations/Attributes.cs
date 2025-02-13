namespace Valuify.Snippets.Declarations;

public static class Attributes
{
    public static readonly Generated Ignore = new(
        IgnoreAttributeGenerator.Content,
        Extensions.None,
        $"{IgnoreAttributeGenerator.Name}Attribute",
        typeof(IgnoreAttributeGenerator));

    public static readonly Generated Valuify = new(
        ValuifyAttributeGenerator.Content,
        Extensions.None,
        $"{ValuifyAttributeGenerator.Name}Attribute",
        typeof(ValuifyAttributeGenerator));
}