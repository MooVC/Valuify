﻿namespace Valuify.Console.PropertyTests;

using Valuify.Console;

public sealed class WhenEqualityIsCheckedByEquatable
    : WhenEqualityIsChecked
{
    private protected override bool AreEqual(Property? instance1, Property? instance2)
    {
        if (instance1 is not null)
        {
            return instance1.Equals(instance2);
        }

        return true;
    }
}