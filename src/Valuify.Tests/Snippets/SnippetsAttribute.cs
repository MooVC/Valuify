namespace Valuify.Snippets;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SnippetsAttribute
    : DataAttribute
{
    private static readonly Lazy<Type[]> declarations = new(GetDeclarations);

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        FieldInfo[] fields = declarations.Value
            .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
            .ToArray();

        foreach (FieldInfo field in fields.Where(field => field.FieldType == typeof(Snippets)))
        {
            object? value = field.GetValue(default);

            if (value is Snippets snippets)
            {
                IEnumerable<Expectations> expectations = snippets.Render();

                foreach (Expectations expectation in expectations)
                {
                    object[]? Prepare(ReferenceAssemblies assembly, LanguageVersion language)
                    {
                        if (language >= expectation.Minimum)
                        {
                            return [assembly, expectation, language];
                        }

                        return default;
                    }

                    foreach (object[] theory in Frameworks.InScope(Prepare))
                    {
                        yield return theory;
                    }
                }
            }
        }
    }

    private static Type[] GetDeclarations()
    {
        return Assembly
            .GetAssembly(typeof(SnippetsAttribute))!
            .GetTypes()
            .Where(type => type.Namespace == "Valuify.Snippets.Declarations")
            .ToArray();
    }
}