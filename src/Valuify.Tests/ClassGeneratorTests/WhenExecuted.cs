namespace Valuify.ClassGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    private static readonly Type[] generators =
    [
        typeof(AttributeGenerator),
        typeof(ClassGenerator),
        typeof(HashCodeGenerator),
        typeof(SequenceEqualityComparerGenerator),
    ];

    [Theory]
    [Snippets]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<ClassGenerator>(assembly, language, generators);

        expectations.IsDeclaredIn(test.TestState);

        Attributes.Valuify.IsExpectedIn(test.TestState);
        Internal.HashCode.IsExpectedIn(test.TestState);
        Internal.SequenceEqualityComparer.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}