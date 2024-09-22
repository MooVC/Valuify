namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>Generates the source needed to support <see cref="IEquatable{T}"/>.</summary>
internal sealed class EquatableStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        if (!subject.IsEquatable)
        {
            yield return GenerateContract(subject);
        }

        if (!subject.HasEquatable)
        {
            yield return GenerateImplementation(subject);
        }
    }

    private static Source GenerateContract(Subject subject)
    {
        string code = $$"""
            partial class {{subject.Qualification}}
                : IEquatable<{{subject.Qualification}}>
            {
            }
            """;

        return new Source(code, nameof(IEquatable<Subject>));
    }

    private static Source GenerateImplementation(Subject subject)
    {
        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public bool Equals({{subject.Qualification}} other)
                {
                    return EqualityComparer<{{subject.Qualification}}>.Default.Equals(this, other);
                }
            }
            """;

        return new Source(code, $"{nameof(IEquatable<Subject>)}.{nameof(Equals)}");
    }
}