namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support <see cref="object.ToString()"/>.</summary>
internal sealed class ToStringStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (subject.HasToStringOverride)
        {
            yield break;
        }

        string value = $"{{nameof({subject.Name})}}";

        if (subject.Properties.Any())
        {
            IEnumerable<string> values = subject
                .Properties
                .Select(property => $"{{nameof({property.Name})}} = {{{property.Name}}}");

            value = $"{value} {{{{ {string.Join(", ", values)} }}}}";
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public sealed override string ToString()
                {
                    return $"{{value}}";
                }
            }
            """;

        yield return new Source(code, nameof(ToString));
    }
}