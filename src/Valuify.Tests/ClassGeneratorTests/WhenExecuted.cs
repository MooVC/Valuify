namespace Valuify.ClassGeneratorTests;

using Valuify.Snippets;

public sealed class WhenExecuted
    : GeneratorTests<ClassGenerator>
{
    private static readonly Type[] generators =
    [
        typeof(AttributeGenerator),
        typeof(ClassGenerator),
        typeof(HashCodeGenerator),
    ];

    public WhenExecuted()
        : base(generators)
    {
    }

    [Theory]
    [Declared(typeof(Classes))]
    public async Task GivenAClassTheExpectedSourceIsGenerated(Declared declared)
    {
        // Arrange
        declared.IsDeclaredIn(TestState);

        Attributes.Valuify.IsExpectedIn(TestState);
        Internal.HashCode.IsExpectedIn(TestState);

        // Act & Assert
        await ActAndAssertAsync();
    }
}