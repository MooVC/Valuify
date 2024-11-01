namespace Valuify;

using System.Reflection;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FrameworksAttribute
    : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
#if CI
        return Frameworks.All();
#else
        return Frameworks.Supported();
#endif
    }
}