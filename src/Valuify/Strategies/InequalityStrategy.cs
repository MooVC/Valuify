namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support the inequality operator.</summary>
internal sealed class InequalityStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (subject.HasInequalityOperator)
        {
            yield break;
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public static bool operator !=({{subject.Qualification}} left, {{subject.Qualification}} right)
                {
                    return !EqualityComparer<{{subject.Qualification}}>.Default.Equals(left, right);
                }
            }
            """;

        yield return new Source(code, "Inequality");
    }
}