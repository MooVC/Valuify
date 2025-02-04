namespace Valuify.Strategies;

using Valuify.Model;

/// <summary>
/// Generates the source needed to support <see cref="IEquatable{T}"/>.
/// </summary>
internal sealed class EquatableStrategy
    : IStrategy
{
    private const string Conditional = "\r\n            && ";

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
        string conditions = "true";

        if (subject.Properties.Count > 0)
        {
            IEnumerable<string> properties = subject.Properties
                .Where(property => !property.IsIgnored)
                .Select(property => $"{GetComparer(property)}.Default.Equals({property.Name}, other.{property.Name})");

            conditions = string.Join(Conditional, properties);
        }

        string code = $$"""
            partial class {{subject.Qualification}}
            {
                public bool Equals({{subject.Qualification}} other)
                {
                    if (ReferenceEquals(this, other))
                    {
                        return true;
                    }
            
                    if (ReferenceEquals(other, null))
                    {
                        return false;
                    }
            
                    return {{conditions}};
                }
            }
            """;

        return new Source(code, $"{nameof(IEquatable<Subject>)}.{nameof(Equals)}");
    }

    private static string GetComparer(Property property)
    {
        return property.IsSequence
            ? $"global::Valuify.Internal.SequenceEqualityComparer"
            : $"global::System.Collections.Generic.EqualityComparer<{property.Type}>";
    }
}