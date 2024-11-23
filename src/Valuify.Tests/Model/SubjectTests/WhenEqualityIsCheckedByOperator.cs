namespace Valuify.Model.SubjectTests;

using Valuify.Model;

public sealed class WhenEqualityIsCheckedByOperator
    : WhenEqualityIsChecked
{
    private protected override bool AreEqual(Subject? instance1, Subject? instance2)
    {
        return instance1 == instance2;
    }
}