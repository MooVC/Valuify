namespace Valuify;

using Microsoft.CodeAnalysis;

/// <summary>Generates an internal SequenceEqualityComparer static class that is used to support enumerable enumerable checks.</summary>
[Generator(LanguageNames.CSharp)]
public sealed class SequenceEqualityComparerGenerator
    : IIncrementalGenerator
{
    /// <summary>The source code that will be output by the generator.</summary>
    public const string Content = $$"""
        namespace Valuify.Internal
        {
            using System;
            using System.Collections;

            internal sealed class SequenceEqualityComparer
            {
                public static readonly SequenceEqualityComparer Default = new SequenceEqualityComparer();

                public bool Equals(IEnumerable left, IEnumerable right)
                {
                    if (ReferenceEquals(left, right))
                    {
                        return true;
                    }

                    if (ReferenceEquals(left, null) || ReferenceEquals(null, right))
                    {
                        return false;
                    }

                    return Equals(left.GetEnumerator(), right.GetEnumerator());
                }
        
                public int GetHashCode(IEnumerable enumerable)
                {
                    return HashCode.Combine(enumerable);
                }

                private static bool Equals(IEnumerator left, IEnumerator right)
                {
                    while (left.MoveNext())
                    {
                        if (!right.MoveNext())
                        {
                            return false;
                        }
        
                        if (!Equals(left.Current, right.Current))
                        {
                            return false;
                        }
                    }
        
                    return !right.MoveNext();
                }
            }
        }
        """;

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(context => context.AddSource("Valuify.Internal.SequenceEqualityComparer.g.cs", Content));
    }
}