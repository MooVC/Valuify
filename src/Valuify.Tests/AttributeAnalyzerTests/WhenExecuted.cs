namespace Valuify.AttributeAnalyzerTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using Valuify.Snippets;
using Valuify.Snippets.Declarations;
using AnalyzerTest = Valuify.AnalyzerTest<Valuify.AttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(exclusions: [typeof(Unsupported)], extensions: Extensions.None)]
    public async Task GivenAClassWhenCompliantThenNoDiagnosticsAreRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.Should().NotThrowAsync();
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
        _ = await act.Should().NotThrowAsync();
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
        _ = await act.Should().NotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenATypeWhenMissingPropertiesThenDefinesPropertiesRuleIsRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language)
        {
            TestCode = """
            using Valuify;

            [Valuify]
            public partial class Empty
            {
            }
            """,
        };

        test.ExpectedDiagnostics.Add(GetExpectedDefinesPropertiesRule(new LinePosition(2, 1), "Empty"));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.Should().NotThrowAsync();
    }

    private static DiagnosticResult GetExpectedCompatibleTargetTypeRule(LinePosition position)
    {
        return new DiagnosticResult(AttributeAnalyzer.CompatibleTargetTypeRule)
            .WithLocation(position);
    }

    private static DiagnosticResult GetExpectedPartialThePartialTypeRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(AttributeAnalyzer.PartialTypeRule)
            .WithLocation(position)
            .WithArguments(@class);
    }

    private static DiagnosticResult GetExpectedDefinesPropertiesRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(AttributeAnalyzer.DefinesPropertiesRule)
            .WithLocation(position)
            .WithArguments(@class);
    }
}