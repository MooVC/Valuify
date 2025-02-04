namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>
/// Generates the source needed to support <see cref="object.Equals(object)"/>.
/// </summary>
internal sealed class EqualsStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (!subject.CanOverrideEquals)
        {
            yield break;
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public override bool Equals(object other)
                {
                    return Equals(other as {{subject.Qualification}});
                }
            }
            """;

        yield return new Source(code, nameof(Equals));
    }
}