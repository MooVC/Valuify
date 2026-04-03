namespace Valuify.Snippets.Declarations;

internal static partial class Nested
{
    public static partial class FourLevels
    {
        public static readonly Snippets Declaration = new(
            [
                CSharp3Body,
            ],
            Declarations.Main,
            [
                Expected.Equality,
            ],
            [
                new(Expected.Equality.Content, Extensions.HasEqualityOperator),
            ],
            nameof(FourLevels));
    }
}