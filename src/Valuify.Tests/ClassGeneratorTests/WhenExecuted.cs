namespace Valuify.ClassGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets;

public sealed class WhenExecuted
{
    private static readonly Type[] generators =
    [
        typeof(AttributeGenerator),
        typeof(ClassGenerator),
        typeof(HashCodeGenerator),
    ];

    [Theory]
    [Declared]
    [Trait("Category", "Integration")]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, string content, Declared declared, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<ClassGenerator>(assembly, language, generators);

        declared.IsDeclaredIn(content, test.TestState);

        Attributes.Valuify.IsExpectedIn(test.TestState);
        Internal.HashCode.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}