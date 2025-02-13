namespace Valuify.Snippets;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Xunit.Sdk;
using static Valuify.Snippets.Extensions;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SnippetsAttribute
    : DataAttribute
{
#if CI

    private const Extensions DefaultExtensions = All;
    private static readonly GetFrameworks frameworks = Frameworks.All;

#else

    private const Extensions DefaultExtensions = None;
    private static readonly GetFrameworks frameworks = Frameworks.Supported;

#endif

    private static readonly ReferenceAssemblies[] assemblies = FindAssemblies();
    private static readonly Type[] declarations = FindDeclarations();
    private static readonly LanguageVersion[] languages = FindLanguages();

    public SnippetsAttribute(Type[]? exclusions = default, Extensions extensions = DefaultExtensions, Type[]? inclusions = default)
    {
        Assemblies = assemblies;
        Extensions = extensions;

        Declarations = inclusions is null
            ? declarations
            : inclusions.Intersect(declarations).ToArray();

        if (exclusions is not null)
        {
            Declarations = Declarations.Except(exclusions).ToArray();
        }

        Languages = languages;
    }

    private delegate IEnumerable<object[]> GetFrameworks(LanguageVersion minimum, Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare);

    public IReadOnlyList<ReferenceAssemblies> Assemblies { get; }

    public IReadOnlyList<Type> Declarations { get; }

    public Extensions Extensions { get; }

    public IReadOnlyList<LanguageVersion> Languages { get; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        FieldInfo[] fields = Declarations
            .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
            .ToArray();

        foreach (FieldInfo field in fields.Where(field => field.FieldType == typeof(Snippets)))
        {
            object? value = field.GetValue(default);

            if (value is Snippets snippets)
            {
                IEnumerable<Expectations> expectations = snippets.Render(Extensions);

                foreach (Expectations expectation in expectations)
                {
                    object[]? Prepare(ReferenceAssemblies assembly, LanguageVersion language)
                    {
                        if (Languages.Contains(language) && Assemblies.Contains(assembly))
                        {
                            return [assembly, expectation, language];
                        }

                        return default;
                    }

                    foreach (object[] theory in frameworks(expectation.Minimum, Prepare))
                    {
                        yield return theory;
                    }
                }
            }
        }
    }

    private static ReferenceAssemblies[] FindAssemblies()
    {
        return Frameworks.InScope
            .Select(framework => framework.Assembly)
            .ToArray();
    }

    private static Type[] FindDeclarations()
    {
        return Assembly
            .GetAssembly(typeof(SnippetsAttribute))!
            .GetTypes()
            .Where(type => type.Namespace == "Valuify.Snippets.Declarations")
            .ToArray();
    }

    private static LanguageVersion[] FindLanguages()
    {
        return Enum.GetValues<LanguageVersion>();
    }
}