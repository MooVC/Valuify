﻿namespace Valuify.Console.NestingTests;

using Valuify.Console;

public sealed class WhenEqualityIsCheckedByOperator
    : WhenEqualityIsChecked
{
    private protected override bool AreEqual(Nesting? instance1, Nesting? instance2)
    {
        return instance1 == instance2;
    }
}