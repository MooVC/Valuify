namespace Valuify
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Valuify.Model;
    using Valuify.Strategies;
    using Valuify.Syntax;

    /// <summary>
    /// Generates source for a class that is annotated with the Valuify attribute.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class ClassGenerator
        : IIncrementalGenerator
    {
        private static readonly IReadOnlyList<IStrategy> _strategies =
        new IStrategy[]
        {
            new EqualityStrategy(),
            new EqualsStrategy(),
            new EquatableStrategy(),
            new GetHashCodeStrategy(),
            new InequalityStrategy(),
            new ToStringStrategy(),
        };

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

#if DEBUG
            var files = new Dictionary<string, string>();
#endif
            foreach (IStrategy strategy in _strategies)
            {
                IEnumerable<Source> sources = strategy.Generate(subject);

                foreach (Source source in sources)
                {
                    string code = Wrap(source.Code, subject);
                    string hint = GetHint(source, subject);

#if DEBUG
                    files[hint] = code;
#endif

                    context.AddSource(hint, code);
                }
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

        private static string Nest(string code, Subject subject)
        {
            foreach (Nesting parent in subject.Nesting.Reverse())
            {
                code = code.Indent();

                code = string.Format(ClassGenerator_Resources.Nest, parent.Declaration, parent.Qualification, code);
            }

            return code;
        }

        private static string Wrap(string code, Subject subject)
        {
            code = Nest(code, subject);
            code = string.Format(ClassGenerator_Resources.Wrap, code);

            if (subject.IsGlobal)
            {
                return code;
            }

            return string.Format(ClassGenerator_Resources.Namespace, subject.Namespace, code.Indent());
        }
    }
}