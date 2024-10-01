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
        { ReferenceAssemblies.NetCore.NetCoreApp20, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetCore.NetCoreApp21, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetCore.NetCoreApp30, LanguageVersion.CSharp8 },
        { ReferenceAssemblies.NetCore.NetCoreApp31, LanguageVersion.CSharp8 },
        { ReferenceAssemblies.NetFramework.Net462.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net47.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net471.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net472.Default, LanguageVersion.CSharp7_3 },
        { ReferenceAssemblies.NetFramework.Net48.Default, LanguageVersion.CSharp7_3 },
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