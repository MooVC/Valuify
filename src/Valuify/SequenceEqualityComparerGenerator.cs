namespace Valuify
{
    using System.Collections;
    using Microsoft.CodeAnalysis;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;

    using static Valuify.SequenceEqualityComparerGenerator_Resources;

    /// <summary>
    /// Generates the internal SequenceEqualityComparer class used to compare enumerable values.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class SequenceEqualityComparerGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The source code that will be output by the generator.
        /// </summary>
        public static readonly string Content = GetContent();

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(initialization => initialization.AddSource("Valuify.Internal.SequenceEqualityComparer.g.cs", Content));
        }

        private static string GetContent()
        {
            const string ComparerName = "SequenceEqualityComparer";
            const string Namespace = "Valuify.Internal";

            Symbol comparer = (Name: ComparerName, Qualifier: Namespace);

            return Definition.Undefined
                .From(Namespace)
                .For<Class>(@class => @class
                    .Named(ComparerName)
                    .WithScope(Scopes.Internal)
                    .WithExtensibility(Modifiers.Sealed)
                    .IsPartial(false)
                    .WithFields(field => field
                        .Named("Default")
                        .OfType(comparer)
                        .WithScope(Scopes.Public)
                        .IsStatic(true)
                        .IsReadOnly(true)
                        .WithDefault($"new {comparer.ToSnippet(Configuration.Options.Types)}()"))
                    .WithMethods(equals => equals
                        .Named("Equals")
                        .Accepts(parameter => parameter.Named("Left").OfType(typeof(IEnumerable)))
                        .Accepts(parameter => parameter.Named("Right").OfType(typeof(IEnumerable)))
                        .Returns(Result.Void.OfType(typeof(bool)))
                        .WithBody(Snippet.From(Configuration.Options, EqualsEnumerableBody)))
                    .WithMethods(getHashCode => getHashCode
                        .Named("GetHashCode")
                        .Accepts(parameter => parameter.Named("Enumerable").OfType(typeof(IEnumerable)))
                        .Returns(Result.Void.OfType(typeof(int)))
                        .WithBody(Snippet.From(Configuration.Options, GetHashCodeBody)))
                    .WithMethods(equals => equals
                        .Named("Equals")
                        .WithScope(Scopes.Private)
                        .WithExtensibility(Modifiers.Static)
                        .Accepts(parameter => parameter.Named("Left").OfType(typeof(IEnumerator)))
                        .Accepts(parameter => parameter.Named("Right").OfType(typeof(IEnumerator)))
                        .Returns(Result.Void.OfType(typeof(bool)))
                        .WithBody(Snippet.From(Configuration.Options, EqualsEnumeratorBody))))
                .ToSnippet(Configuration.Options);
        }
    }
}