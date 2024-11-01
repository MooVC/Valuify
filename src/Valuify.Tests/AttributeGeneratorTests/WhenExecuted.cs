﻿namespace Valuify.AttributeGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Valuify.Snippets.Declarations;

public sealed class WhenExecuted
{
    [Theory]
    [Frameworks]
    [Trait("Category", "Integration")]
    public async Task GivenAnAssemblyThenTheAttributeIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<AttributeGenerator>(assemblies, language);

        Attributes.Valuify.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.Should().NotThrowAsync();
    }
}