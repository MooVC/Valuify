namespace Valuify.Snippets;

using System;
using Shouldly;
using Valuify.Snippets.Declarations;
using Xunit;
using Inherited = Valuify.Snippets.Declarations.Inherited;
using Nested = Valuify.Snippets.Declarations.Nested;

public sealed class WhenEquatableImplementationsAreRendered
{
    private static readonly Generated[] EquatableImplementations =
    [
        Explicit.Expected.EquatableImplementation,
        Generics.Expected.EquatableImplementation,
        Ignored.Expected.EquatableImplementation,
        Inherited.FromSealed.Expected.EquatableImplementation,
        Inherited.FromVirtual.Expected.EquatableImplementation,
        Nested.InClass.Expected.EquatableImplementation,
        Nested.InInterface.Expected.EquatableImplementation,
        Nested.InRecord.Expected.EquatableImplementation,
        Nested.InRecordStruct.Expected.EquatableImplementation,
        Nested.InStruct.Expected.EquatableImplementation,
        Simple.Expected.EquatableImplementation,
    ];

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
}
