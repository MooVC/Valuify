namespace Valuify
{
    using System.Collections;
    using Microsoft.CodeAnalysis;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;

    using static Valuify.HashCodeGenerator_Resources;

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
        public static readonly string Content = GetContent();

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(initialization => initialization.AddSource("Valuify.Internal.HashCode.g.cs", Content));
        }

        private static string GetContent()
        {
            return Definition.Undefined
                .From("Valuify.Internal")
                .For<Class>(@class => @class
                    .Named("HashCode")
                    .WithScope(Scopes.Internal)
                    .IsPartial(false)
                    .IsStatic(true)
                    .WithMethods(combine => combine
                        .Named("Combine")
                        .WithExtensibility(Modifiers.Static)
                        .Accepts(parameter => parameter
                            .Named("Values")
                            .OfType(((Symbol)typeof(object)).IsArray(true))
                            .WithModifier(Parameter.Modes.Params))
                        .Returns(Result.Void.OfType(typeof(int)))
                        .WithBody(Snippet.From(Configuration.Options, CombineBody)))
                    .WithMethods(getHashCode => getHashCode
                        .Named("GetHashCode")
                        .WithExtensibility(Modifiers.Static)
                        .Accepts(parameter => parameter.Named("Value").OfType(typeof(object)))
                        .Returns(Result.Void.OfType(typeof(int)))
                        .WithBody(Snippet.From(Configuration.Options, GetHashCodeBody)))
                    .WithMethods(combineEnumerable => combineEnumerable
                        .Named("CombineEnumerable")
                        .WithScope(Scopes.Private)
                        .WithExtensibility(Modifiers.Static)
                        .Accepts(parameter => parameter.Named("Hash").OfType(typeof(int)))
                        .Accepts(parameter => parameter.Named("Values").OfType(typeof(IEnumerable)))
                        .Returns(Result.Void.OfType(typeof(int)))
                        .WithBody(Snippet.From(Configuration.Options, CombineEnumerableBody)))
                    .WithMethods(performCombine => performCombine
                        .Named("PerformCombine")
                        .WithScope(Scopes.Private)
                        .WithExtensibility(Modifiers.Static)
                        .Accepts(parameter => parameter.Named("Hash").OfType(typeof(int)))
                        .Accepts(parameter => parameter.Named("Value").OfType(typeof(object)))
                        .Returns(Result.Void.OfType(typeof(int)))
                        .WithBody(Snippet.From(Configuration.Options, PerformCombineBody))))
                .ToSnippet(Configuration.Options);
        }
    }
}