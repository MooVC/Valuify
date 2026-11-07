namespace Valuify.Snippets;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets.Declarations;

internal static class SnippetCases
{
#if CI
    private const Extensions DefaultExtensions = Extensions.All;
#else
    private const Extensions DefaultExtensions = Extensions.None;
#endif

    private static readonly string _declarationsNamespace = typeof(Attributes).Namespace!;
    private static readonly Type[] _declarations = typeof(SnippetCases).Assembly.GetTypes()
        .Where(type => type.Namespace == _declarationsNamespace)
        .ToArray();

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> Create(
        Type[]? inclusions = null,
        Type[]? exclusions = null,
        Extensions extensions = DefaultExtensions)
    {
        IEnumerable<Type> declarations = inclusions is null ? _declarations : inclusions.Intersect(_declarations);
        if (exclusions is not null)
        {
            declarations = declarations.Except(exclusions);
        }

        IEnumerable<FieldInfo> fields = declarations
            .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
            .Where(field => field.FieldType == typeof(Snippets));

        foreach (FieldInfo field in fields)
        {
            if (field.GetValue(null) is Snippets snippets)
            {
                string declaration = field.DeclaringType!.FullName![(_declarationsNamespace.Length + 1)..].Replace('+', '.');
                var variant = 0;

                foreach (Expectations expectation in snippets.Render(extensions))
                {
                    variant++;

                    foreach ((ReferenceAssemblies assembly, LanguageVersion language) in Frameworks.Cases(expectation.Minimum))
                    {
                        yield return new(
                            (assembly, expectation, language),
                            DisplayName: $"{declaration}.{field.Name} [{variant}] ({assembly.TargetFramework}, {language})");
                    }
                }
            }
        }
    }
}