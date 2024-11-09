namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support the equality operator.</summary>
internal sealed class EqualityStrategy
    : IStrategy
{
    private const string Conditional = "\r\n            && ";

    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (subject.HasEqualityOperator)
        {
            yield break;
        }

        string conditions = string.Empty;

        if (subject.Properties.Count > 0)
        {
            IEnumerable<string> properties = subject.Properties
                .Select(property => $"{GetComparer(property)}.Default.Equals(left.{property.Name}, right.{property.Name})");

            conditions = string.Join(Conditional, properties);
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public static bool operator ==({{subject.Qualification}} left, {{subject.Qualification}} right)
                {
                    if (ReferenceEquals(left, right))
                    {
                        return true;
                    }

                    if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                    {
                        return false;
                    }

                    return {{conditions}};
                }
            }
            """;

        yield return new Source(code, "Equality");
    }

    private static string GetComparer(Property property)
    {
        return $"EqualityComparer<{property.Type}>";
    }
}