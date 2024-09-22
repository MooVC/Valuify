namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support the equality operator.</summary>
internal sealed class EqualityStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (subject.HasEqualityOperator)
        {
            yield break;
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public static bool operator ==({{subject.Qualification}} left, {{subject.Qualification}} right)
                {
                    return EqualityComparer<{{subject.Qualification}}>.Default.Equals(left, right);
                }
            }
            """;

        yield return new Source(code, "Equality");
    }
}