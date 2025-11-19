namespace Valuify.Snippets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shouldly;
using Valuify.Snippets.Declarations;
using Xunit;
using Inherited = Valuify.Snippets.Declarations.Inherited;
using Nested = Valuify.Snippets.Declarations.Nested;

public sealed class WhenEquatableImplementationsAreRendered
{
    private static readonly Generated[] EquatableImplementations = GetEquatableImplementations().ToArray();

    [Fact]
    public void GivenEquatableSnapshotsWhenInspectingEqualsThenReferenceCheckPrecedesNullCheck()
    {
        foreach (Generated implementation in EquatableImplementations)
        {
            int referenceEqualsIndex = implementation.Content.IndexOf(
                "if (ReferenceEquals(this, other))",
                StringComparison.Ordinal);

            referenceEqualsIndex.ShouldBeGreaterThanOrEqualTo(0);

            int nullCheckIndex = implementation.Content.IndexOf(
                "return !ReferenceEquals(other, null)",
                StringComparison.Ordinal);

            nullCheckIndex.ShouldBeGreaterThan(referenceEqualsIndex);
        }
    }

    private static IEnumerable<Generated> GetEquatableImplementations()
    {
        IEnumerable<Type> declarations = typeof(Explicit).Assembly
            .GetTypes()
            .Where(type => type is { Namespace: "Valuify.Snippets.Declarations", IsAbstract: true, IsSealed: true })
            .OrderBy(type => type.FullName);

        foreach (Type declaration in declarations)
        {
            Type? expected = declaration.GetNestedType(
                "Expected",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            FieldInfo? implementation = expected?.GetField(
                "EquatableImplementation",
                BindingFlags.Public | BindingFlags.Static);

            if (implementation?.GetValue(null) is Generated generated)
            {
                yield return generated;
            }
        }
    }
}
