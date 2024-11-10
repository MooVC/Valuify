﻿namespace Valuify.Console.PropertyTests;

public abstract class WhenInequalityIsChecked
{
    [Fact]
    public void GivenIdenticalInstancesThenTheyAreDeemedEqual()
    {
        // Arrange
        var instance1 = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "string[]",
        };

        var instance2 = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "string[]",
        };

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentNameThenTheyAreNotDeemedEqual()
    {
        // Arrange
        var instance1 = new Property
        {
            IsSequence = true,
            Name = "PropertyName1",
            Type = "string[]",
        };

        var instance2 = new Property
        {
            IsSequence = true,
            Name = "PropertyName2",
            Type = "string[]",
        };

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenTheyAreDeemedNotEqual()
    {
        // Arrange
        var instance1 = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "string[]",
        };

        var instance2 = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "Name[]",
        };

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenOneInstanceIsNullThenTheyAreDeemedNotEqual()
    {
        // Arrange
        var instance = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "string[]",
        };

        // Act
        bool areNotEqual = AreNotEqual(instance, default);

        // Assert
        _ = areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenBothInstancesAreNullThenTheyAreDeemedEqual()
    {
        // Arrange
        Property? instance1 = default;
        Property? instance2 = default;

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenTheyAreDeemedEqual()
    {
        // Arrange
        var instance1 = new Property
        {
            IsSequence = true,
            Name = "PropertyName",
            Type = "string[]",
        };

        Property instance2 = instance1;

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
    }

    private protected abstract bool AreNotEqual(Property? instance1, Property? instance2);
}