# VALFY02: Type is not Partial

<table>
<tr>
  <td>Type Name</td>
  <td>VALFY02_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>VALFY02</td>
</tr>
<tr>
  <td>Category</td>
  <td>Usage</td>
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

The declaration for a `class` annotated with the `Valuify` attribute is not marked as partial.

## Rule Description

A violation of this rule occurs when a `class` is not marked with the `partial` keyword when the `Valuify` attribute is applied. The `partial` keyword is needed to facilitate the generation of additional content within the assembly for the type.

For example:

```csharp
[Valuify]
public class Example
{
    public int Value { get; set; }
}
```

In this example, `Example` is excluded from Valuify's consideration as the declaration is not `partial` and as a result, no additional content can be generated without resulting in an compilation failure.

## How to Fix Violations

Reevaluate the decision to apply the `Valuify` attribute. If the intention is correct, add the `partial` keyword to the declaration, otherwise remove the `Valuify` attribute.

For example:

```csharp
[Valuify]
public partial class Example
{
    public int Value { get; set; }
}
```
or alternatively:

```csharp
public class Example
{
    public int Value { get; set; }
}
```

## When to Suppress Warnings

It is not recommended to suppress the rule. Instead, it is suggested that the usage of the `Valuify` attribute be reevaluated.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable VALFY02 // Type is not Partial
[Valuify]
public class Example
{
    public int Value { get; set; }
    
}
#pragma warning restore VALFY02 // Type is not Partial
```

or alternatively:

```csharp
[Valuify]
[SuppressMessage("Design", "VALFY02:Type is not Partial", Justification = "Explanation for suppression")]
public class Example
{
    public int Value { get; set; }
}
```

## How to Disable VALFY02

It is not recommended to disable the rule, as this may result in some confusion if the expected equality behavior is not observed.

```ini
# Disable VALFY02: Descriptor is disregarded from consideration by Valuify
[*.cs]
dotnet_diagnostic.VALFY02.severity = none
```