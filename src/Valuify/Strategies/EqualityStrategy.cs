namespace Valuify.Strategies;

using System.Collections.Generic;
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
                    if (ReferenceEquals(left, right))
                    {
                        return true;
                    }

                    if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                    {
                        return false;
                    }

                    return left.Equals(right);
                }
            }
            """;

        yield return new Source(code, "Equality");
    }
}