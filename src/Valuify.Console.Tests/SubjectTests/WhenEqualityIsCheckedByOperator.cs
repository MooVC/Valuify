namespace Valuify.Console.SubjectTests;

using Valuify.Console;

public sealed class WhenEqualityIsCheckedByOperator
    : WhenEqualityIsChecked
{
    private protected override bool AreEqual(Subject? instance1, Subject? instance2)
    {
        return instance1 == instance2;
    }
}