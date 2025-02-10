namespace Valuify.IgnoreAttributeAnalyzerTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using Valuify.Snippets;
using Valuify.Snippets.Declarations;
using AnalyzerTest = Valuify.AnalyzerTest<Valuify.IgnoreAttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(exclusions: [typeof(Unannotated)], extensions: Extensions.None)]
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

    [Fact]
    public async Task GivenATypeWhenUnannotatedThenCompatibleTargetTypeRuleIsRaised()
    {
        Dictionary<LanguageVersion, LinePosition> positions = new()
        {
            { LanguageVersion.CSharp2, new LinePosition(18, 9) },
            { LanguageVersion.CSharp3, new LinePosition(11, 9) },
            { LanguageVersion.CSharp6, new LinePosition(8, 9) },
            { LanguageVersion.CSharp9, new LinePosition(8, 9) },
        };

        foreach (Expectations expectation in Unannotated.Declaration.Render(Extensions.None))
        {
            // Arrange
            var test = new AnalyzerTest(ReferenceAssemblies.Net.Net90, expectation.Minimum);

            expectation.IsDeclaredIn(test.TestState);

            test.ExpectedDiagnostics.Add(GetExpectedMissingValuifyRule(positions[expectation.Minimum]));

            // Act
            Func<Task> act = () => test.RunAsync();

            // Assert
            await act.ShouldNotThrowAsync();
        }
    }

    private static DiagnosticResult GetExpectedMissingValuifyRule(LinePosition position)
    {
        return new DiagnosticResult(IgnoreAttributeAnalyzer.MissingValuifyRule)
            .WithLocation(position);
    }
}