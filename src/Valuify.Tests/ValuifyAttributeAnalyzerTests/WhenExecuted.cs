namespace Valuify.ValuifyAttributeAnalyzerTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using Valuify.Snippets;
using Valuify.Snippets.Declarations;
using static Valuify.Snippets.Declarations.Inherited;
using AnalyzerTest = Valuify.AnalyzerTest<Valuify.ValuifyAttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(exclusions: [typeof(FromSealed), typeof(Redundant), typeof(Unsupported)], extensions: Extensions.None)]
    public async Task GivenAClassWhenCompliantThenNoDiagnosticsAreRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks(Language = LanguageVersion.CSharp9)]
    public async Task GivenATypeWhenIncompatibleThenCompatibleTargetTypeRuleIsRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language)
        {
            TestCode = """
            using Valuify;

            [Valuify]
            public partial record Incompatible(int Age, string Name);
            """,
        };

        test.ExpectedDiagnostics.Add(GetExpectedCompatibleTargetTypeRule(new LinePosition(2, 1)));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Snippets(inclusions: [typeof(Unsupported)])]
    public async Task GivenATypeWhenNotPartialThenPartialTypeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedPartialThePartialTypeRule(new LinePosition(2, 5), nameof(Unsupported)));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Snippets(inclusions: [typeof(FromSealed)])]
    public async Task GivenATypeWhenBaseIsSealedThenEqualityGuarenteeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language, typeof(ClassGenerator), typeof(IgnoreAttributeGenerator), typeof(ValuifyAttributeGenerator));

        test.ExpectedDiagnostics.Add(GetExpectedEqualityGuarenteeRule(new LinePosition(20, 5), nameof(Inherited), nameof(Equals)));
        test.ExpectedDiagnostics.Add(GetExpectedEqualityGuarenteeRule(new LinePosition(20, 5), nameof(Inherited), nameof(GetHashCode)));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenATypeWhenMissingPropertiesThenDefinesPropertiesRuleIsRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        const string className = "Empty";
        const string testCode = """
            using Valuify;

            [Valuify]
            public partial class Empty
            {
            }
            """;

        var test = new AnalyzerTest(assembly, language)
        {
            TestCode = testCode,
        };

        test.ExpectedDiagnostics.Add(GetExpectedDefinesPropertiesRule(new LinePosition(2, 1), className));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks(Language = LanguageVersion.CSharp6)]
    public async Task GivenATypeWithOnlyIndexerThenDefinesPropertiesRuleIsRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        const string className = "WithIndexer";
        const string testCode = """
            using Valuify;

            [Valuify]
            public partial class WithIndexer
            {
                public int this[int index] => index;
            }
            """;

        var test = new AnalyzerTest(assembly, language)
        {
            TestCode = testCode,
        };

        test.ExpectedDiagnostics.Add(GetExpectedDefinesPropertiesRule(new LinePosition(2, 1), className));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static DiagnosticResult GetExpectedCompatibleTargetTypeRule(LinePosition position)
    {
        return new DiagnosticResult(ValuifyAttributeAnalyzer.CompatibleTargetTypeRule)
            .WithLocation(position);
    }

    private static DiagnosticResult GetExpectedPartialThePartialTypeRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(ValuifyAttributeAnalyzer.PartialTypeRule)
            .WithLocation(position)
            .WithArguments(@class);
    }

    private static DiagnosticResult GetExpectedDefinesPropertiesRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(ValuifyAttributeAnalyzer.DefinesPropertiesRule)
            .WithLocation(position)
            .WithArguments(@class);
    }

    private static DiagnosticResult GetExpectedEqualityGuarenteeRule(LinePosition position, string @class, string method)
    {
        return new DiagnosticResult(ValuifyAttributeAnalyzer.EqualityGuarenteeRule)
            .WithLocation(position)
            .WithArguments(@class, method);
    }
}