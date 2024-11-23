namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class InClass
    {
        public static readonly Snippets Declaration = new(
            [
                CSharp2Body,
                CSharp3Body,
                CSharp6Body,
                CSharp9Body,
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
            nameof(InClass));
    }
}