namespace Valuify.Model.SubjectTests;

using Valuify.Model;

public sealed class WhenInequalityIsCheckedByOperator
    : WhenInequalityIsChecked
{
    private protected override bool AreNotEqual(Subject? instance1, Subject? instance2)
    {
        return instance1 != instance2;
    }
}