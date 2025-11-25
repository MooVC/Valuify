namespace Valuify.HashCodeGeneratorTests;

using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    [Fact]
    public void GivenValuesInDifferentPositionsThenHashesAreDifferent()
    {
        // Arrange
        MethodInfo combine = CreateCombineMethod();

        // Act
        int firstHash = (int)combine.Invoke(null, new object[] { new object?[] { 1, 0 } })!;
        int secondHash = (int)combine.Invoke(null, new object[] { new object?[] { 0, 1 } })!;

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenNestedEnumerablesWhenElementOrderDiffersThenHashesAreDifferent()
    {
        // Arrange
        MethodInfo combine = CreateCombineMethod();

        // Act
        int firstHash = (int)combine.Invoke(null, new object[] { new object?[] { 1, new object?[] { 2, 3 } } })!;
        int secondHash = (int)combine.Invoke(null, new object[] { new object?[] { 1, new object?[] { 3, 2 } } })!;

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

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

    private static MethodInfo CreateCombineMethod()
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(HashCodeGenerator.Content);

        CSharpCompilation compilation = CSharpCompilation.Create(
            assemblyName: "Valuify.HashCode",
            syntaxTrees: [syntaxTree],
            references:
            [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Collections.IEnumerable).Assembly.Location),
            ],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var stream = new MemoryStream();
        EmitResult emitResult = compilation.Emit(stream);

        emitResult.Success.ShouldBeTrue();

        stream.Seek(0, SeekOrigin.Begin);

        Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(stream);
        Type hashCode = assembly.GetType("Valuify.Internal.HashCode")!;

        return hashCode.GetMethod("Combine", [typeof(object[])])!;
    }
}