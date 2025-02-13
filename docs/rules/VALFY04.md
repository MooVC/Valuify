# VALFY04: Type does not utilize Valuify

<table>
<tr>
  <td>Type Name</td>
  <td>VALFY04_IgnoreAttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>VALFY04</td>
</tr>
<tr>
  <td>Category</td>
  <td>Usage</td>
</tr>
<tr>
  <td>Severity</td>
  <td>Info</td>
</tr>
<tr>
  <td>Is Enabled By Default</td>
  <td>Yes</td>
</tr>
</table>

## Cause

The property is not considered by Valuify because the type has not been annotated with the `Valuify` attribute.

## Rule Description

A violation of this rule occurs when a property is marked with the `Ignore` attribute, but the containing `class` is not annotated with the `Valuify` attribute. Therefore, no extension methods will be generated, making use of the `Ignore` attribute redundant.

For example:

```csharp
public class Example
{
    [Ignore]
    public string Property { get; set; }
}
```

In this example, the `Ignore` attribute on `Property`, and the `class` itself, will be ignored by `Valuify`, suggesting a misunderstanding by the engineer as to its intended usage.

## How to Fix Violations

Reevaluate the decision to apply the `Ignore` attribute. If the `Ignore` attribute usage is deemed correct, annotate the type with the `Valuify` attribute, otherwise remove the `Ignore` attribute.

For example:

```csharp
[Valuify]
public class Example
{
    [Ignore]
    public string Property { get; set; }
}
```
or alternatively:

```csharp
public class Example
{
    public string Property { get; set; }
}
```

## When to Suppress Warnings

Warnings from this rule should be suppressed only if there is a strong justification for not using the `Valuify` attribute on the containing type when the `Ignore` attribute is applied.

If suppression is desired, one of the following approaches can be used:

```csharp
[Valuify]
public class Example
{
    #pragma warning disable VALFY04 // Type does not utilize Valuify
    
    [Ignore]
    public string Property { get; set; }
    
    #pragma warning restore VALFY04 // Type does not utilize Valuify
}
```

or alternatively:

```csharp
public class Example
{
    [Ignore]
    [SuppressMessage("Usage", "VALFY04:Type does not utilize Valuify", Justification = "Explanation for suppression")]
    public string Property { get; set; }
}
```

## How to Disable VALFY04

It is not recommended to disable the rule, as this may result in some confusion if expected extension methods are not present.

```ini
# Disable VALFY04: Type does not utilize Valuify
[*.cs]
dotnet_diagnostic.VALFY04.severity = none
```