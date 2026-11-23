namespace Valuify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using MooVC.Syntax;
    using Valuify.Model;
    using Valuify.Syntax;

    /// <summary>
    /// Generates source for a class that is annotated with the Valuify attribute.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class ClassGenerator
        : IIncrementalGenerator
    {
        private static readonly IServiceProvider _services = new GenerationServices();

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            IncrementalValuesProvider<ClassDeclarationSyntax> classes = context
                .SyntaxProvider
                .CreateSyntaxProvider(predicate: IsMatch, transform: Transform)
                .Where(record => record is object);

            IncrementalValuesProvider<Subject> subjects = classes
               .Combine(context.CompilationProvider)
               .Select((match, cancellationToken) => match.Left.ToSubject(match.Right, cancellationToken));

            context.RegisterSourceOutput(subjects, Generate);
        }

        private static void Generate(SourceProductionContext context, Subject subject)
        {
            if (subject is null)
            {
                return;
            }

            var navigator = new SubjectNavigator(_services);

            foreach (Source source in navigator.Navigate<Source>(subject))
            {
                Snippet code = Wrap(source.Code, subject);
                string hint = GetHint(source, subject);
                context.AddSource(hint, code.ToString());
            }
        }

        private static string GetHint(Source source, Subject subject)
        {
            string name = subject.Name;

            if (subject.Nesting.Count > 0)
            {
                IEnumerable<string> names = subject.Nesting
                    .Select(parent => parent.Name)
                    .Union(new[] { name });

                name = string.Join(".", names);
            }

            return $"{subject.Namespace}.{name}.{source.Hint}.g.cs";
        }

        private static bool IsMatch(SyntaxNode node, CancellationToken cancellationToken)
        {
            return node is ClassDeclarationSyntax @class && @class.AttributeLists.Count > 0;
        }

        private static ClassDeclarationSyntax Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            return context.Node as ClassDeclarationSyntax;
        }

        private static Snippet Wrap(Snippet code, Subject subject)
        {
            foreach (Nesting parent in subject.Nesting.Reverse())
            {
                code = code.Block(Configuration.Options, $"{parent.Declaration} {parent.Qualification}");
            }

            return subject.IsGlobal ? code : code.Block(Configuration.Options, $"namespace {subject.Namespace}");
        }
    }
}