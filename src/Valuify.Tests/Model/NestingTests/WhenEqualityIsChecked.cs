namespace Valuify.Model.NestingTests;

public abstract class WhenEqualityIsChecked
{
    [Fact]
    public void GivenIdenticalInstancesThenTheyAreDeemedEqual()
    {
        // Arrange
        var instance1 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "class",
        };

        var instance2 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "class",
        };

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenADifferentNameThenTheyAreNotDeemedEqual()
    {
        // Arrange
        var instance1 = new Nesting
        {
            Name = "Simple1",
            Qualification = "Complex",
            Type = "class",
        };

        var instance2 = new Nesting
        {
            Name = "Simple2",
            Qualification = "Complex",
            Type = "class",
        };

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentQualificationThenTheyAreNotDeemedEqual()
    {
        // Arrange
        var instance1 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex1",
            Type = "class",
        };

        var instance2 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex2",
            Type = "class",
        };

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenTheyAreDeemedNotEqual()
    {
        // Arrange
        var instance1 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "class",
        };

        var instance2 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "struct",
        };

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenOneInstanceIsNullThenTheyAreDeemedNotEqual()
    {
        // Arrange
        var instance = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "class",
        };

        // Act
        bool areEqual = AreEqual(instance, default);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenBothInstancesAreNullThenTheyAreDeemedEqual()
    {
        // Arrange
        Nesting? instance1 = default;
        Nesting? instance2 = default;

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenTheyAreDeemedEqual()
    {
        // Arrange
        var instance1 = new Nesting
        {
            Name = "Simple",
            Qualification = "Complex",
            Type = "class",
        };

        Nesting instance2 = instance1;

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    private protected abstract bool AreEqual(Nesting? instance1, Nesting? instance2);
}