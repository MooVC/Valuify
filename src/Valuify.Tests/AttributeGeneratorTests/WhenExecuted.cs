namespace Valuify.AttributeGeneratorTests;

using Valuify.Snippets;

public sealed class WhenExecuted
    : GeneratorTests<AttributeGenerator>
{
    [Fact]
    public async Task GivenAnAssemblyThenTheAttributeIsGenerated()
    {
        // Arrange
        Attributes.Valuify.IsExpectedIn(TestState);

        // Act & Assert
        await ActAndAssertAsync();
    }
}