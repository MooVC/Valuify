namespace Valuify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;

public sealed class GeneratorTest<TGenerator>
    : CSharpSourceGeneratorTest<TGenerator, DefaultVerifier>
    where TGenerator : new()
{
    private readonly Type[] generators;
    private readonly LanguageVersion language;

    public GeneratorTest(ReferenceAssemblies assembly, LanguageVersion language, params Type[] generators)
    {
        this.generators = generators.Length == 0
            ? [typeof(TGenerator)]
            : generators;

        this.language = language;
        ReferenceAssemblies = assembly;
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(language);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return generators;
    }
}