namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support <see cref="object.ToString()"/>.</summary>
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

        if (subject.Properties.Any())
        {
            IEnumerable<string> values = subject
                .Properties
                .Select((property, index) => $"{property.Name} = {{{index}}}");

            value = $"{subject.Name} {{ {string.Join(", ", values)} }}";

            IEnumerable<string> properties = subject.Properties.Select(property => property.Name);
            string parameters = string.Join(", ", properties);

            value = $"string.Format(\"{value}\", {parameters})";
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