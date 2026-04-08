namespace Valuify.ClassGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
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

    [Theory]
    [Snippets]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<ClassGenerator>(assembly, language, _generators);

        expectations.IsDeclaredIn(test.TestState);

        Attributes.Ignore.IsExpectedIn(test.TestState);
        Attributes.Valuify.IsExpectedIn(test.TestState);
        Internal.HashCode.IsExpectedIn(test.TestState);
        Internal.SequenceEqualityComparer.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}