namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>
/// Generates the source needed to support <see cref="object.ToString()"/>.
/// </summary>
internal sealed class ToStringStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (!subject.CanOverrideToString)
        {
            yield break;
        }

        string value = $"\"{subject.Name}\"";

        Property[] properties = subject.Properties
            .Where(property => !property.IsIgnored)
            .ToArray();

        if (properties.Length > 0)
        {
            IEnumerable<string> values = properties.Select(property => $"{property.Name} = {{{property.Name}}}");

            value = $"$\"{subject.Name} {{{{ {string.Join(", ", values)} }}}}\"";
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public override string ToString()
                {
                    return {{value}};
                }
            }
            """;

        yield return new Source(code, nameof(ToString));
    }
}
