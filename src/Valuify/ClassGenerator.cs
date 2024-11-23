namespace Valuify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Valuify.Model;
using Valuify.Strategies;
using Valuify.Syntax;

/// <summary>Generates source for a class that is annotated with the Valuify attribute.</summary>
[Generator(LanguageNames.CSharp)]
public sealed class ClassGenerator
    : IIncrementalGenerator
{
    private static readonly IReadOnlyList<IStrategy> strategies =
    [
        new EqualityStrategy(),
        new EqualsStrategy(),
        new EquatableStrategy(),
        new GetHashCodeStrategy(),
        new InequalityStrategy(),
        new ToStringStrategy(),
    ];

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<ClassDeclarationSyntax?> classes = context
            .SyntaxProvider
            .CreateSyntaxProvider(predicate: IsMatch, transform: Transform)
            .Where(record => record is not null);

        IncrementalValuesProvider<Subject?> subjects = classes
           .Combine(context.CompilationProvider)
           .Select(static (match, cancellationToken) => match.Left.ToSubject(match.Right, cancellationToken))
           .Where(subject => subject is not null);

        context.RegisterSourceOutput(subjects, Generate);
    }

    private static void Generate(SourceProductionContext context, Subject? subject)
    {
        if (subject is not null)
        {
            foreach (IStrategy strategy in strategies)
            {
                IEnumerable<Source> sources = strategy.Generate(subject);

                foreach (Source source in sources)
                {
                    string code = Wrap(source.Code, subject);
                    string hint = GetHint(source, subject);

                    context.AddSource(hint, code);
                }
            }
        }
    }

    private static string GetHint(Source source, Subject subject)
    {
        string name = subject.Name;

        if (subject.Nesting.Count > 0)
        {
            IEnumerable<string> names = subject.Nesting
                .Reverse()
                .Select(parent => parent.Name)
                .Union([name]);

            name = string.Join(".", names);
        }

        return $"{subject.Namespace}.{name}.{source.Hint}.g.cs";
    }

    private static bool IsMatch(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is ClassDeclarationSyntax @class && @class.AttributeLists.Count > 0;
    }

    private static ClassDeclarationSyntax? Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        return context.Node as ClassDeclarationSyntax;
    }

    private static string Nest(string code, Subject subject)
    {
        foreach (Nesting parent in subject.Nesting)
        {
            code = code.Indent();

            code = $$"""
                {{parent.Declaration}} {{parent.Qualification}}
                {
                    {{code}}
                }
                """;
        }

        return code;
    }

    private static string Wrap(string code, Subject subject)
    {
        code = Nest(code, subject);

        code = $$"""
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif
            
            {{code}}
            
            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
            """;

        if (subject.IsGlobal)
        {
            return code;
        }

        return $$"""
            namespace {{subject.Namespace}}
            {
                {{code.Indent()}}
            }
            """;
    }
}