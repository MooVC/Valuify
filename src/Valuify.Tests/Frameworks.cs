namespace Valuify;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static class Frameworks
{
    public static readonly IReadOnlyList<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportTo)> InScope =
    [
        (ReferenceAssemblies.Net.Net50, LanguageVersion.CSharp9, new DateOnly(2022, 5, 10)),
        (ReferenceAssemblies.Net.Net60, LanguageVersion.CSharp10, new DateOnly(2024, 11, 12)),
        (ReferenceAssemblies.Net.Net70, LanguageVersion.CSharp11, new DateOnly(2024, 5, 14)),
        (ReferenceAssemblies.Net.Net80, LanguageVersion.CSharp12, new DateOnly(2026, 5, 13)),
        (ReferenceAssemblies.NetCore.NetCoreApp20, LanguageVersion.CSharp7_3, new DateOnly(2018, 10, 1)),
        (ReferenceAssemblies.NetCore.NetCoreApp21, LanguageVersion.CSharp7_3, new DateOnly(2021, 8, 21)),
        (ReferenceAssemblies.NetCore.NetCoreApp30, LanguageVersion.CSharp8, new DateOnly(2020, 3, 3)),
        (ReferenceAssemblies.NetCore.NetCoreApp31, LanguageVersion.CSharp8, new DateOnly(2022, 12, 3)),
        (ReferenceAssemblies.NetFramework.Net462.Default, LanguageVersion.CSharp7_3, new DateOnly(2022, 4, 26)),
        (ReferenceAssemblies.NetFramework.Net47.Default, LanguageVersion.CSharp7_3, DateOnly.MaxValue),
        (ReferenceAssemblies.NetFramework.Net471.Default, LanguageVersion.CSharp7_3, DateOnly.MaxValue),
        (ReferenceAssemblies.NetFramework.Net472.Default, LanguageVersion.CSharp7_3, DateOnly.MaxValue),
        (ReferenceAssemblies.NetFramework.Net48.Default, LanguageVersion.CSharp7_3, DateOnly.MaxValue),
        (ReferenceAssemblies.NetStandard.NetStandard20, LanguageVersion.CSharp7_3, DateOnly.MaxValue),
        (ReferenceAssemblies.NetStandard.NetStandard21, LanguageVersion.CSharp8, DateOnly.MaxValue),
    ];

    private static readonly LanguageVersion[] languages;

    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "It cannot be initialized inline.")]
    static Frameworks()
    {
        languages = Enum.GetValues<LanguageVersion>();
    }

    public static IEnumerable<object[]> All(Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare = default)
    {
        return Filter(InScope, maximum => languages.Where(language => language <= maximum), prepare);
    }

    public static IEnumerable<object[]> Supported(Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare = default)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return Filter(InScope.Where(framework => framework.SupportTo >= today), maximum => [maximum], prepare);
    }

    private static IEnumerable<object[]> Filter(
        IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportedTo)> frameworks,
        Func<LanguageVersion, IEnumerable<LanguageVersion>> languages,
        Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare)
    {
        prepare ??= (assembly, language) => [assembly, language];

        foreach ((ReferenceAssemblies assembly, LanguageVersion maximum, DateOnly _) in frameworks)
        {
            foreach (LanguageVersion language in languages(maximum))
            {
                object[]? payload = prepare(assembly, language);

                if (payload is not null)
                {
                    yield return payload;
                }
            }
        }
    }
}