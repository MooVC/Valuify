namespace Valuify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;

public abstract class GeneratorTests<TGenerator>
    : CSharpSourceGeneratorTest<TGenerator, DefaultVerifier>
    where TGenerator : new()
{
    private readonly Type[] generators;

    protected GeneratorTests(params Type[] generators)
    {
        this.generators = generators.Length == 0
            ? [typeof(TGenerator)]
            : generators;
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(LanguageVersion.CSharp7);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return generators;
    }

    protected Task ActAndAssertAsync()
    {
        return RunAsync();
    }
}