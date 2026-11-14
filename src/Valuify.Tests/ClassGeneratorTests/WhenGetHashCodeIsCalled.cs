namespace Valuify.ClassGeneratorTests;

using System.Collections.Immutable;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenGetHashCodeIsCalled
{
    private const int FirstValue = 1;
    private const int SecondValue = 2;
    private const int FirstEnumeration = 3;
    private const int SecondEnumeration = 4;

    [Test]
    [Arguments("Sequence")]
    [Arguments("Array")]
    [Arguments("Box")]
    public async Task GivenEnumerableValuesThenGeneratedHashingUsesTheirValueSemantics(string owner)
    {
        // Arrange
        const string source = """
            using System;
            using System.Collections;
            using System.Collections.Generic;
            using System.Collections.Immutable;
            using Valuify;

            [Valuify]
            public sealed partial class Sequence
            {
                public ImmutableArray<Item> Items { get; init; }
            }

            [Valuify]
            public sealed partial class Array
            {
                public Item[] Items { get; init; }
            }

            [Valuify]
            public sealed partial class Box
            {
                public object Item { get; init; }
            }

            public sealed class Item(int value, int enumerated) : IEquatable<Item>, IEnumerable<int>
            {
                private int Value { get; } = value;

                public bool Equals(Item other) => other is not null && Value == other.Value;

                public override bool Equals(object other) => Equals(other as Item);

                public override int GetHashCode() => Value;

                public IEnumerator<int> GetEnumerator()
                {
                    yield return enumerated;
                }

                IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }

            public static class Probe
            {
                public static object Create(string owner, int value, int enumerated)
                {
                    var item = new Item(value, enumerated);

                    return owner switch
                    {
                        nameof(Box) => new Box { Item = item },
                        nameof(Array) => new Array { Items = new[] { item } },
                        _ => new Sequence { Items = ImmutableArray.Create(item) },
                    };
                }
            }
            """;
        var options = new CSharpParseOptions(LanguageVersion.CSharp14);
        ImmutableArray<MetadataReference> references = await ReferenceAssemblies.Net.Net100.ResolveAsync(LanguageNames.CSharp, CancellationToken.None);
        var input = CSharpCompilation.Create(
            "Valuify.GeneratedHashCodeTest",
            [CSharpSyntaxTree.ParseText(source, options)],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            [
                new ClassGenerator().AsSourceGenerator(),
                new HashCodeGenerator().AsSourceGenerator(),
                new IgnoreAttributeGenerator().AsSourceGenerator(),
                new SequenceEqualityComparerGenerator().AsSourceGenerator(),
                new ValuifyAttributeGenerator().AsSourceGenerator(),
            ],
            parseOptions: options);

        driver.RunGeneratorsAndUpdateCompilation(input, out Compilation compilation, out _);
        using var stream = new MemoryStream();
        EmitResult emitted = compilation.Emit(stream);
        emitted.Success.ShouldBeTrue(string.Join(Environment.NewLine, emitted.Diagnostics));

        Assembly assembly = Assembly.Load(stream.ToArray());
        var create = assembly.GetType("Probe")!.GetMethod("Create")!.CreateDelegate<Func<string, int, int, object>>();

        // Act
        object first = create(owner, FirstValue, FirstEnumeration);
        object sameValue = create(owner, FirstValue, SecondEnumeration);
        object differentValue = create(owner, SecondValue, FirstEnumeration);

        // Assert
        first.Equals(sameValue).ShouldBeTrue();
        first.GetHashCode().ShouldBe(sameValue.GetHashCode());
        first.Equals(differentValue).ShouldBeFalse();
        first.GetHashCode().ShouldNotBe(differentValue.GetHashCode());
    }
}