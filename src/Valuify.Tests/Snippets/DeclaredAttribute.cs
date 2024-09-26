namespace Valuify.Snippets;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class DeclaredAttribute
    : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        FieldInfo[] fields = typeof(Classes).GetFields(BindingFlags.Public | BindingFlags.Static);

        foreach (FieldInfo field in fields.Where(field => field.FieldType == typeof(Declared)))
        {
            object? value = field.GetValue(default);

            if (value is Declared declared)
            {
                IEnumerable<Content> contents = declared.Render();

                foreach (Content content in contents)
                {
                    object[]? Prepare(ReferenceAssemblies assembly, LanguageVersion language)
                    {
                        if (language >= content.Minimum)
                        {
                            return [assembly, content.Body, declared, language];
                        }

                        return default;
                    }

                    foreach (object[] theory in Frameworks.All(Prepare))
                    {
                        yield return theory;
                    }
                }
            }
        }
    }
}