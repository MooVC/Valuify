namespace Valuify.Snippets.Declarations;

internal static partial class Ignored
{
    public static readonly Snippets Declaration = new(
        [
            Declarations.CSharp1Body,
            Declarations.CSharp3Body,
            Declarations.CSharp6Body,
            Declarations.CSharp9Body,
        ],
        Declarations.Main,
        [
            Expected.Equality,
            Expected.Equals,
            Expected.EquatableContract,
            Expected.EquatableImplementation,
            Expected.GetHashCode,
            Expected.Inequality,
            Expected.ToString,
        ],
        [
            new(Expected.Equality.Content, Extensions.HasEqualityOperator),
            new(Expected.Equals.Content, Extensions.HasEqualsOverride),
            new(Expected.EquatableContract.Content, Extensions.IsEquatable),
            new(Expected.EquatableImplementation.Content, Extensions.HasEquatable),
            new(Expected.GetHashCode.Content, Extensions.HasGetHashCodeOverride),
            new(Expected.Inequality.Content, Extensions.HasInequalityOperator),
            new(Expected.ToString.Content, Extensions.HasToStringOverride),
        ],
        nameof(Ignored));
}