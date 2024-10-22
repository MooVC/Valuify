namespace Valuify.Model.NestingTests;

using Valuify.Model;

public sealed class WhenInequalityIsCheckedByOperator
    : WhenInequalityIsChecked
{
    private protected override bool AreNotEqual(Nesting? instance1, Nesting? instance2)
    {
        return instance1 != instance2;
    }
}