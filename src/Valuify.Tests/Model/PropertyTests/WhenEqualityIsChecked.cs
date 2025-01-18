namespace Valuify.Model.PropertyTests;

public abstract class WhenEqualityIsChecked
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
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentIsSequenceThenTheyAreNotDeemedEqual()
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
            IsSequence = false,
            Name = "PropertyName",
            Type = "string[]",
        };

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeFalse();
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
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeFalse();
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
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeFalse();
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
        bool areEqual = AreEqual(instance, default);

        // Assert
        areEqual.ShouldBeFalse();
    }

    [Fact]
    public void GivenBothInstancesAreNullThenTheyAreDeemedEqual()
    {
        // Arrange
        Property? instance1 = default;
        Property? instance2 = default;

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeTrue();
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
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        areEqual.ShouldBeTrue();
    }

    private protected abstract bool AreEqual(Property? instance1, Property? instance2);
}