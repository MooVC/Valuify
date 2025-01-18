namespace Valuify.HashCodeGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    [Theory]
    [Frameworks]
    public async Task GivenAnAssemblyThenTheClassIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<HashCodeGenerator>(assemblies, language);

        Internal.HashCode.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}