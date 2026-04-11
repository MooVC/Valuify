namespace Valuify.Snippets.Declarations;

internal static partial class AnnotatedEquatable
{
    public static readonly Snippets Declaration = new(
        [
            Declarations.CSharp9Body,
        ],
        Declarations.Main,
        [
            Expected.Collection.Equality,
            Expected.Collection.Equals,
            Expected.Collection.EquatableContract,
            Expected.Collection.EquatableImplementation,
            Expected.Collection.GetHashCode,
            Expected.Collection.Inequality,
            Expected.Collection.ToString,
            Expected.Subject.Equality,
            Expected.Subject.Equals,
            Expected.Subject.EquatableContract,
            Expected.Subject.EquatableImplementation,
            Expected.Subject.GetHashCode,
            Expected.Subject.Inequality,
            Expected.Subject.ToString,
        ],
        [
            new(Expected.Collection.Equality.Content, Extensions.HasEqualityOperator),
            new(Expected.Collection.Equals.Content, Extensions.HasEqualsOverride),
            new(Expected.Collection.EquatableContract.Content, Extensions.IsEquatable),
            new(Expected.Collection.EquatableImplementation.Content, Extensions.HasEquatable),
            new(Expected.Collection.GetHashCode.Content, Extensions.HasGetHashCodeOverride),
            new(Expected.Collection.Inequality.Content, Extensions.HasInequalityOperator),
            new(Expected.Collection.ToString.Content, Extensions.HasToStringOverride),
            new(Expected.Subject.Equality.Content, Extensions.HasEqualityOperator),
            new(Expected.Subject.Equals.Content, Extensions.HasEqualsOverride),
            new(Expected.Subject.EquatableContract.Content, Extensions.IsEquatable),
            new(Expected.Subject.EquatableImplementation.Content, Extensions.HasEquatable),
            new(Expected.Subject.GetHashCode.Content, Extensions.HasGetHashCodeOverride),
            new(Expected.Subject.Inequality.Content, Extensions.HasInequalityOperator),
            new(Expected.Subject.ToString.Content, Extensions.HasToStringOverride),
        ],
        nameof(AnnotatedEquatable));
}