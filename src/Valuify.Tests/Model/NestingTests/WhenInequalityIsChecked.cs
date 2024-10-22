namespace Valuify.Model.NestingTests;

public abstract class WhenInequalityIsChecked
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
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
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
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeTrue();
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
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeTrue();
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
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeTrue();
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
        bool areNotEqual = AreNotEqual(instance, default);

        // Assert
        _ = areNotEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenBothInstancesAreNullThenTheyAreDeemedEqual()
    {
        // Arrange
        Nesting? instance1 = default;
        Nesting? instance2 = default;

        // Act
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
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
        bool areNotEqual = AreNotEqual(instance1, instance2);

        // Assert
        _ = areNotEqual.Should().BeFalse();
    }

    private protected abstract bool AreNotEqual(Nesting? instance1, Nesting? instance2);
}