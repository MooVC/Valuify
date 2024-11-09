namespace Valuify;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FrameworksAttribute
    : DataAttribute
{
    public LanguageVersion Language { get; } = LanguageVersion.CSharp2;

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
#if CI
        return Frameworks.All(Language);
#else
        return Frameworks.Supported(Language);
#endif
    }
}