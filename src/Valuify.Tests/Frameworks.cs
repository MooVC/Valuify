namespace Valuify;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static class Frameworks
{
    private static readonly Dictionary<ReferenceAssemblies, LanguageVersion> frameworks = new()
    {
        { ReferenceAssemblies.Net.Net50, LanguageVersion.CSharp9 },
        { ReferenceAssemblies.Net.Net60, LanguageVersion.CSharp10 },
        { ReferenceAssemblies.Net.Net70, LanguageVersion.CSharp11 },
        { ReferenceAssemblies.Net.Net80, LanguageVersion.CSharp12 },
        { ReferenceAssemblies.NetCore.NetCoreApp10, LanguageVersion.CSharp6 },
        { ReferenceAssemblies.NetCore.NetCoreApp11, LanguageVersion.CSharp7 },
        { ReferenceAssemblies.NetCore.NetCoreApp20, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetCore.NetCoreApp21, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetCore.NetCoreApp30, LanguageVersion.CSharp8 },
        { ReferenceAssemblies.NetCore.NetCoreApp31, LanguageVersion.CSharp8 },
        { ReferenceAssemblies.NetFramework.Net20.Default, LanguageVersion.CSharp2 },
        { ReferenceAssemblies.NetFramework.Net35.Default, LanguageVersion.CSharp3 },
        { ReferenceAssemblies.NetFramework.Net40.Default, LanguageVersion.CSharp4 },
        { ReferenceAssemblies.NetFramework.Net45.Default, LanguageVersion.CSharp5 },
        { ReferenceAssemblies.NetFramework.Net451.Default, LanguageVersion.CSharp5 },
        { ReferenceAssemblies.NetFramework.Net452.Default, LanguageVersion.CSharp5 },
        { ReferenceAssemblies.NetFramework.Net46.Default, LanguageVersion.CSharp6 },
        { ReferenceAssemblies.NetFramework.Net461.Default, LanguageVersion.CSharp7 },
        { ReferenceAssemblies.NetFramework.Net462.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net47.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net471.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net472.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net48.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard10, LanguageVersion.CSharp6 },
        { ReferenceAssemblies.NetStandard.NetStandard11, LanguageVersion.CSharp6 },
        { ReferenceAssemblies.NetStandard.NetStandard12, LanguageVersion.CSharp7 },
        { ReferenceAssemblies.NetStandard.NetStandard13, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard14, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard15, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard16, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard20, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetStandard.NetStandard21, LanguageVersion.CSharp8 },
    };

    private static readonly LanguageVersion[] languages;

    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "It cannot be initialized inline.")]
    static Frameworks()
    {
        languages = Enum.GetValues<LanguageVersion>();
    }

    public static IEnumerable<object[]> All(Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare = default)
    {
        prepare ??= (assembly, language) => [assembly, language];

        foreach (KeyValuePair<ReferenceAssemblies, LanguageVersion> framework in frameworks)
        {
            foreach (LanguageVersion language in languages.Where(language => language <= framework.Value))
            {
                object[]? payload = prepare(framework.Key, language);

                if (payload is not null)
                {
                    yield return payload;
                }
            }
        }
    }
}