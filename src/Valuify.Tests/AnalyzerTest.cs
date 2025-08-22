namespace Valuify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

public sealed class AnalyzerTest<TAnalyzer>
    : CSharpAnalyzerTest<TAnalyzer, DefaultVerifier>
    where TAnalyzer : DiagnosticAnalyzer, new()
{
    private readonly Type[] _generators;
    private readonly LanguageVersion _languageVersion;

    public AnalyzerTest(ReferenceAssemblies assemblies, LanguageVersion languageVersion, params Type[] generators)
    {
        _generators = generators.Length == 0
            ? [typeof(IgnoreAttributeGenerator), typeof(ValuifyAttributeGenerator)]
            : generators;

        _languageVersion = languageVersion;
        ReferenceAssemblies = assemblies;
        TestBehaviors = TestBehaviors.SkipGeneratedSourcesCheck;
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(_languageVersion);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return _generators;
    }
}