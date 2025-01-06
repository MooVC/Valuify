﻿namespace Valuify.Model.SubjectTests;

public abstract class WhenEqualityIsChecked
{
    [Fact]
    public void GivenIdenticalInstancesThenTheyAreDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create();
        Subject instance2 = Create();

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenADifferentCanOverrideEqualsThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.CanOverrideEquals = true);
        Subject instance2 = Create(subject => subject.CanOverrideEquals = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentCanOverrideGetHashCodeThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.CanOverrideGetHashCode = true);
        Subject instance2 = Create(subject => subject.CanOverrideGetHashCode = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentCanOverrideToStringThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.CanOverrideToString = true);
        Subject instance2 = Create(subject => subject.CanOverrideToString = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentHasEqualityOperatorThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.HasEqualityOperator = true);
        Subject instance2 = Create(subject => subject.HasEqualityOperator = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentHasEquatableThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.HasEquatable = true);
        Subject instance2 = Create(subject => subject.HasEquatable = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentHasInequalityOperatorThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.HasInequalityOperator = true);
        Subject instance2 = Create(subject => subject.HasInequalityOperator = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentIsEquatableThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.IsEquatable = true);
        Subject instance2 = Create(subject => subject.IsEquatable = false);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentNameThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.Name = "SubjectName1");
        Subject instance2 = Create(subject => subject.Name = "SubjectName2");

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentNamespaceThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.Namespace = "Valuify.Testing");
        Subject instance2 = Create(subject => subject.Namespace = "Valuify.Tests");

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentNestingThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.Nesting = [new() { Qualification = "Outter", Declaration = "partial class" }]);
        Subject instance2 = Create(subject => subject.Nesting = []);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentPropertiesThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create();
        Subject instance2 = Create(subject => subject.Properties = []);

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenADifferentQualificationThenTheyAreNotDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create(subject => subject.Qualification = "Subject");
        Subject instance2 = Create(subject => subject.Qualification = "Subject<T>");

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenOneInstanceIsNullThenTheyAreDeemedNotEqual()
    {
        // Arrange
        Subject instance = Create();

        // Act
        bool areEqual = AreEqual(instance, default);

        // Assert
        _ = areEqual.Should().BeFalse();
    }

    [Fact]
    public void GivenBothInstancesAreNullThenTheyAreDeemedEqual()
    {
        // Arrange
        Subject? instance1 = default;
        Subject? instance2 = default;

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenTheyAreDeemedEqual()
    {
        // Arrange
        Subject instance1 = Create();
        Subject instance2 = instance1;

        // Act
        bool areEqual = AreEqual(instance1, instance2);

        // Assert
        _ = areEqual.Should().BeTrue();
    }

    private protected abstract bool AreEqual(Subject? instance1, Subject? instance2);

    private static Subject Create(Action<Subject>? mutator = default)
    {
        var property = new Property { Name = "PropertyName", Type = "string" };

        var instance = new Subject
        {
            CanOverrideEquals = true,
            CanOverrideGetHashCode = true,
            CanOverrideToString = true,
            HasEqualityOperator = true,
            HasEquatable = true,
            HasInequalityOperator = true,
            IsEquatable = true,
            Name = "SubjectName",
            Namespace = "Valuify.Testing",
            Nesting = [new() { Qualification = "Outter", Declaration = "partial class" }],
            Properties = [property],
            Qualification = "SubjectName<T>",
        };

        mutator?.Invoke(instance);

        return instance;
    }
}