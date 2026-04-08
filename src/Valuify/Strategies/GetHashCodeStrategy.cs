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
            .Select(Format);

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

    private static string Format(Property property)
    {
        if (property.IsSequence && !property.IsImmutableArray && (property.IsEquatable || property.HasValuify))
        {
            return $"global::Valuify.Internal.HashCode.GetHashCode({property.Name})";
        }

        return property.Name;
    }
}