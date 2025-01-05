namespace Valuify.Snippets.Declarations;

internal static partial class Inherited
{
    public static partial class FromSealed
    {
        public static readonly Snippets Declaration = new(
        [
            CSharp1Body,
            CSharp3Body,
            CSharp6Body,
            CSharp9Body,
        ],
        Declarations.Main,
        [
            Expected.Equality,
            Expected.EquatableContract,
            Expected.EquatableImplementation,
            Expected.Inequality,
        ],
        [
            new(Expected.Equality.Content, Extensions.HasEqualityOperator),
            new(Expected.EquatableContract.Content, Extensions.IsEquatable),
            new(Expected.EquatableImplementation.Content, Extensions.HasEquatable),
            new(Expected.Inequality.Content, Extensions.HasInequalityOperator),
        ],
        nameof(FromSealed));
    }
}