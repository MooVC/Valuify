# VALFY05: Valuify cannot guarantee Equality

<table>
<tr>
  <td>Type Name</td>
  <td>VALFY05_ValuifyAttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>VALFY05</td>
</tr>
<tr>
  <td>Category</td>
  <td>Design</td>
</tr>
<tr>
  <td>Severity</td>
  <td>Warning</td>
</tr>
<tr>
  <td>Is Enabled By Default</td>
  <td>Yes</td>
</tr>
</table>

## Cause

The type inherits from a base `class` that has a override for `Equals` and/or `GetHashCode` that is marked with the `sealed` keyword, preventing `Valuify` from overriding the behaviors, undermining its ability to guarantee `record` like equality behavior.

## Rule Description

A violation of this rule occurs when `Valuify` is applied to a type that inherits from a base `class` that has a override for `Equals` and/or `GetHashCode` that is marked with the `sealed` keyword, preventing `Valuify` from overriding the behaviors, undermining its ability to guarantee `record` like equality behavior.

For example:

```csharp
public class Base
{
    public sealed override bool Equals(object obj)
        => base.Equals(obj);

    public sealed override int GetHashCode()
        => base.GetHashCode();
}

[Valuify]
public class Example
    : Base
{
    public string Property { get; set; }
}
```

In this example, `Base` has applied the `sealed` keyword to both `Equals` and `GetHashCode`, preventing `Valuify` from providing an override for `Example` that ensures `record` like equality behavior.

## How to Fix Violations

Reevaluate the decision to apply the `Valuify` attribute. If the behavior of the `sealed` base methods aligns with the requirements, then this warning can be ignored, otherwise remove the `Valuify` attribute and apply an alternative implementation that aligns with the requirements.

## When to Suppress Warnings

Warnings from this rule should be suppressed only if there the base implementation aligns with the requirements, otherwise the `Valuify` attribute should be removed from the containing type.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable VALFY05 // Type does not utilize Valuify
[Valuify]
public class Example
    : Base
{
    public string Property { get; set; }
}
#pragma warning restore VALFY05 // Type does not utilize Valuify
```

or alternatively:

```csharp
[SuppressMessage("Usage", "VALFY05:Valuify cannot guarantee Equality", Justification = "Explanation for suppression")]
[Valuify]
public class Example
    : Base
{
    public string Property { get; set; }
}
```

## How to Disable VALFY05

It is not recommended to disable the rule, as this may result in some confusion if expected extension methods are not present.

```ini
# Disable VALFY05: Valuify cannot guarantee Equality
[*.cs]
dotnet_diagnostic.VALFY05.severity = none
```