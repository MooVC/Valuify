﻿namespace Valuify.Console.SubjectTests;

using Valuify.Console;

public sealed class WhenEqualityIsCheckedByEquals
    : WhenEqualityIsChecked
{
    private protected override bool AreEqual(Subject? instance1, Subject? instance2)
    {
        if (instance1 is not null)
        {
            return instance1.Equals((object?)instance2);
        }

        return true;
    }
}