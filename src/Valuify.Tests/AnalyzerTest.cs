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
    private readonly Type[] generators;
    private readonly LanguageVersion languageVersion;

    public AnalyzerTest(ReferenceAssemblies assemblies, LanguageVersion languageVersion, params Type[] generators)
    {
        this.generators = generators.Length == 0
            ? [typeof(IgnoreAttributeGenerator), typeof(ValuifyAttributeGenerator)]
            : generators;

        this.languageVersion = languageVersion;
        ReferenceAssemblies = assemblies;
        TestBehaviors = TestBehaviors.SkipGeneratedSourcesCheck;
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(languageVersion);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return generators;
    }
}