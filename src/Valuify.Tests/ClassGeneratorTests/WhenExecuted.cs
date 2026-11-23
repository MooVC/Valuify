namespace Valuify.ClassGeneratorTests;

using System.Collections.Immutable;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    private static readonly Type[] _generators =
    [
        typeof(ClassGenerator),
        typeof(HashCodeGenerator),
        typeof(IgnoreAttributeGenerator),
        typeof(SequenceEqualityComparerGenerator),
        typeof(ValuifyAttributeGenerator),
    ];

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> ClassGenerationCases()
    {
        return SnippetCases.Create();
    }

    [Test]
    [MethodDataSource(nameof(ClassGenerationCases))]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<ClassGenerator>(assembly, language, _generators);

        expectations.IsDeclaredIn(test.TestState);

        Internal.HashCode.IsExpectedIn(test.TestState);
        Attributes.Ignore.IsExpectedIn(test.TestState);
        Internal.SequenceEqualityComparer.IsExpectedIn(test.TestState);
        Attributes.Valuify.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Test]
    public async Task GivenIgnoredAndShadowingPropertiesThenEqualityUsesOnlyNonIgnoredValues()
    {
        // Arrange
        const string declaration = """
            using Valuify;

            namespace Testing
            {
                [Valuify]
                internal sealed partial class AllIgnored
                {
                    [Ignore]
                    public int Value { get; set; }
                }

                [Valuify]
                internal sealed partial class Shadowing
                {
                    public int other { get; set; }
                }

                public static class EqualityProbe
                {
                    public static (bool IgnoredValuesMatch, bool EqualValuesMatch, bool DifferentValuesMatch) Run()
                    {
                        var first = new Shadowing { other = 1 };
                        return (
                            new AllIgnored { Value = 1 }.Equals(new AllIgnored { Value = 2 }),
                            first.Equals(new Shadowing { other = 1 }),
                            first.Equals(new Shadowing { other = 2 }));
                    }
                }
            }
            """;

        // Act
        (bool IgnoredValuesMatch, bool EqualValuesMatch, bool DifferentValuesMatch) result =
            await CompileAndRun<(bool IgnoredValuesMatch, bool EqualValuesMatch, bool DifferentValuesMatch)>(declaration);

        // Assert
        result.ShouldBe((true, true, false));
    }

    [Test]
    public async Task GivenNestedTypeParametersWithTheSameNameThenEqualityUsesTheNestedType()
    {
        // Arrange
        const string declaration = """
            using Valuify;

            namespace Testing
            {
                public partial class Outer<T>
                {
                    #pragma warning disable CS0693
                    [Valuify]
                    public sealed partial class Inner<T>
                    {
                        public T Value { get; set; }
                    }
                    #pragma warning restore CS0693
                }

                public static class EqualityProbe
                {
                    public static bool Run()
                    {
                        var first = new Outer<int>.Inner<string> { Value = "first" };
                        return first.Equals(new Outer<int>.Inner<string> { Value = "first" })
                            && !first.Equals(new Outer<int>.Inner<string> { Value = "second" });
                    }
                }
            }
            """;

        // Act
        bool result = await CompileAndRun<bool>(declaration);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public async Task GivenTypesNamedWithAttributeSuffixThenEqualityUsesTheFullNames()
    {
        // Arrange
        const string declaration = """
            using Valuify;

            namespace Testing
            {
                public sealed class ItemAttribute
                {
                }

                [Valuify]
                public sealed partial class ValueAttribute
                {
                    public ItemAttribute Item { get; set; }
                }

                public static class EqualityProbe
                {
                    public static bool Run()
                    {
                        var item = new ItemAttribute();
                        var first = new ValueAttribute { Item = item };
                        return first == new ValueAttribute { Item = item }
                            && first != new ValueAttribute { Item = new ItemAttribute() };
                    }
                }
            }
            """;

        // Act
        bool result = await CompileAndRun<bool>(declaration);

        // Assert
        result.ShouldBeTrue();
    }

    private static async Task<TResult> CompileAndRun<TResult>(string declaration)
    {
        var options = new CSharpParseOptions(LanguageVersion.CSharp7_3);
        ImmutableArray<MetadataReference> references = await ReferenceAssemblies.Net.Net100.ResolveAsync(LanguageNames.CSharp, CancellationToken.None);
        var compilation = CSharpCompilation.Create(
            "Valuify.EqualityProbe",
            [CSharpSyntaxTree.ParseText(declaration, options)],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        IEnumerable<ISourceGenerator> generators = _generators.Select(type => ((IIncrementalGenerator)Activator.CreateInstance(type)!).AsSourceGenerator());
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generators, parseOptions: options);

        _ = driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation generated, out _);
        using var stream = new MemoryStream();
        EmitResult emitted = generated.Emit(stream);

        emitted.Success.ShouldBeTrue(string.Join(Environment.NewLine, emitted.Diagnostics));
        Assembly assembly = Assembly.Load(stream.ToArray());
        MethodInfo method = assembly.GetType("Testing.EqualityProbe")!.GetMethod("Run")!;
        return method.CreateDelegate<Func<TResult>>()();
    }
}