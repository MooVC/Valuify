namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>
/// Generates the source needed to support <see cref="object.Equals(object)"/>.
/// </summary>
internal sealed class GetHashCodeStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (!subject.CanOverrideGetHashCode)
        {
            yield break;
        }

        IEnumerable<string> properties = subject.Properties
            .Where(property => !property.IsIgnored)
            .Select(property => property.Name);

        string combine = string.Join(", ", properties);

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public override int GetHashCode()
                {
                    return global::Valuify.Internal.HashCode.Combine({{combine}});
                }
            }
            """;

        yield return new Source(code, nameof(GetHashCode));
    }
}