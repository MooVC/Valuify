namespace Valuify;

using Microsoft.CodeAnalysis;

/// <summary>Generates an internal HashCode static class that is used to support hash code generation.</summary>
[Generator(LanguageNames.CSharp)]
public sealed class HashCodeGenerator
    : IIncrementalGenerator
{
    /// <summary>The source code that will be output by the generator.</summary>
    public const string Content = $$"""
        namespace Valuify.Internal
        {
            using System;
            using System.Collections;

            internal static class HashCode
            {
                private const int HashSeed = 0x1505;
                private const int HashPrime = -1521134295;

                public static int Combine(params object[] values)
                {
                    int hash = HashSeed;

                    foreach (object value in values)
                    {
                        if (value is IEnumerable && !(value is string))
                        {
                            IEnumerable enumerable = (IEnumerable)value;
        
                            foreach (object element in enumerable)
                            {
                                hash = PerformCombine(hash, element);
                            }
                        }
                        else
                        {
                            hash = PerformCombine(hash, value);
                        }
                    }

                    return hash;
                }
        
                private static int PerformCombine(int hash, object value)
                {
                    int other = GetHashCode(value);

                    unchecked
                    {
                        return (other * HashPrime) + hash;
                    }
                }

                private static int GetHashCode(object value)
                {
                    int code = 0;

                    if (value != null)
                    {
                        code = value.GetHashCode();
                    }

                    return code;
                }
            }
        }
        """;

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(context => context.AddSource("Valuify.Internal.HashCode.g.cs", Content));
    }
}