namespace Valuify.Snippets;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static partial class Classes
{
    public static readonly ReferenceAssemblies[] AllFrameworks =
    [
        ReferenceAssemblies.Net.Net50,
        ReferenceAssemblies.Net.Net60,
        ReferenceAssemblies.Net.Net70,
        ReferenceAssemblies.Net.Net80,
        ReferenceAssemblies.NetCore.NetCoreApp10,
        ReferenceAssemblies.NetCore.NetCoreApp11,
        ReferenceAssemblies.NetCore.NetCoreApp20,
        ReferenceAssemblies.NetCore.NetCoreApp21,
        ReferenceAssemblies.NetCore.NetCoreApp30,
        ReferenceAssemblies.NetCore.NetCoreApp31,
        ReferenceAssemblies.NetFramework.Net20.Default,
        ReferenceAssemblies.NetFramework.Net35.Default,
        ReferenceAssemblies.NetFramework.Net40.Default,
        ReferenceAssemblies.NetFramework.Net45.Default,
        ReferenceAssemblies.NetFramework.Net451.Default,
        ReferenceAssemblies.NetFramework.Net452.Default,
        ReferenceAssemblies.NetFramework.Net46.Default,
        ReferenceAssemblies.NetFramework.Net461.Default,
        ReferenceAssemblies.NetFramework.Net462.Default,
        ReferenceAssemblies.NetFramework.Net47.Default,
        ReferenceAssemblies.NetFramework.Net471.Default,
        ReferenceAssemblies.NetFramework.Net472.Default,
        ReferenceAssemblies.NetFramework.Net48.Default,
        ReferenceAssemblies.NetStandard.NetStandard10,
        ReferenceAssemblies.NetStandard.NetStandard11,
        ReferenceAssemblies.NetStandard.NetStandard12,
        ReferenceAssemblies.NetStandard.NetStandard13,
        ReferenceAssemblies.NetStandard.NetStandard14,
        ReferenceAssemblies.NetStandard.NetStandard15,
        ReferenceAssemblies.NetStandard.NetStandard16,
        ReferenceAssemblies.NetStandard.NetStandard20,
        ReferenceAssemblies.NetStandard.NetStandard21,
    ];

    public static readonly LanguageVersion[] AllVersions =
    [
        LanguageVersion.CSharp1,
        LanguageVersion.CSharp2,
        LanguageVersion.CSharp3,
        LanguageVersion.CSharp4,
        LanguageVersion.CSharp5,
        LanguageVersion.CSharp6,
        LanguageVersion.CSharp7,
        LanguageVersion.CSharp7_1,
        LanguageVersion.CSharp7_2,
        LanguageVersion.CSharp7_3,
        LanguageVersion.CSharp8,
        LanguageVersion.CSharp9,
        LanguageVersion.CSharp10,
        LanguageVersion.CSharp11,
        LanguageVersion.CSharp12,
    ];

    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "Needed due to order constraint.")]
    static Classes()
    {
        Simple = new(
            SimpleContent,
            LanguageVersion.CSharp1,
            LanguageVersion.Latest,
            nameof(Simple),
            SimpleEquality,
            SimpleEquals,
            SimpleEquatableContract,
            SimpleEquatableImplementation,
            SimpleGetHashCode,
            SimpleInequality,
            SimpleToString);

        Unannotated = new(
            UnannotatedContent,
            LanguageVersion.CSharp1,
            LanguageVersion.Latest,
            nameof(Unannotated));

        Unsupported = new(
            UnsupportedContent,
            LanguageVersion.CSharp1,
            LanguageVersion.Latest,
            nameof(Unsupported));
    }
}