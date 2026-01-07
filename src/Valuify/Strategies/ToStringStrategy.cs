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
            IEnumerable<string> values = properties.Select((property, index) => $"{property.Name} = {{{index}}}");

            string format = $"{subject.Name} {{{{ {string.Join(", ", values)} }}}}";

            IEnumerable<string> names = properties.Select(property => property.Name);
            string parameters = string.Join(", ", names);

            value = $"string.Format(\"{format}\", {parameters})";
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