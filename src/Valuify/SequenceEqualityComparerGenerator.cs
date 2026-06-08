namespace Valuify
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Generates an internal SequenceEqualityComparer static class that is used to support enumerable enumerable checks.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class SequenceEqualityComparerGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The source code that will be output by the generator.
        /// </summary>
        public static readonly string Content = SequenceEqualityComparerGenerator_Resources.Content;

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(initialization => initialization.AddSource("Valuify.Internal.SequenceEqualityComparer.g.cs", Content));
        }
    }
}