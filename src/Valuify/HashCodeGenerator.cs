namespace Valuify
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Generates an internal HashCode static class that is used to support hash code generation.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class HashCodeGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The source code that will be output by the generator.
        /// </summary>
        public static readonly string Content = HashCodeGenerator_Resources.Content;

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(initialization => initialization.AddSource("Valuify.Internal.HashCode.g.cs", Content));
        }
    }
}