namespace Valuify.SequenceEqualityComparerGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    private static readonly Type[] generators =
    [
        typeof(HashCodeGenerator),
        typeof(SequenceEqualityComparerGenerator),
    ];

    [Theory]
    [Frameworks]
    public async Task GivenAnAssemblyThenTheClassIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<SequenceEqualityComparerGenerator>(assemblies, language, generators: generators);

        Internal.HashCode.IsExpectedIn(test.TestState);
        Internal.SequenceEqualityComparer.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}