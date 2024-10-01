namespace Valuify.Snippets;

[Flags]
public enum Extensions
    : byte
{
    None = 0,
    HasEqualityOperator = 0b0000_0001,
    HasEqualsOverride = 0b0000_0010,
    HasEquatable = 0b0000_0100,
    HasGetHashCodeOverride = 0b0000_1000,
    HasInequalityOperator = 0b0001_0000,
    HasToStringOverride = 0b0010_0000,
    IsEquatable = 0b0100_0000,
    All = 0b0111_1111,
}