# VALFY03: Type does not define Properties

<table>
<tr>
  <td>Type Name</td>
  <td>VALFY03_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>VALFY03</td>
</tr>
<tr>
  <td>Category</td>
  <td>Design</td>
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

À `class` upon which `Valuify` is applied does not define any properties.

## Rule Description

A violation of this rule occurs when a type annotated with the `Valuify` attribute does not define any properties, either within the declaration itself or within its base type. Equality will therefore be based solely upon the type, indicating a potential flaw in the design.

For example:

```csharp
[Valuify]
public partial class Example
{
}
```

## How to Fix Violations

Reevaluate the decision to apply the `Valuify` attribute. If the type is intended to define no properties, then usage of the `Valuify` attribute is not recommended.

For example:

```csharp
public class Example
{
}
```
or alternatively:

```csharp
[Valuify]
public partial class Example
{
    public int Value { get; set; }
}
```

## When to Suppress Warnings

It is not recommended to suppress the rule. Instead, it is suggested that the usage of the `Valuify` attribute be reevaluated.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable VALFY03 // Type does not define Properties
[Valuify]
public partial class Example
{
}
#pragma warning restore VALFY03 // Type does not define Properties
```

or alternatively:

```csharp
[Valuify]
[SuppressMessage("Design", "VALFY03:Type does not define Properties", Justification = "Explanation for suppression")]
public partial class Example
{
}
```

## How to Disable VALFY03

It is not recommended to disable the rule, as this may result in some confusion if the expected equality behavior is not observed.

```ini
# Disable VALFY03: Type does not define Properties
[*.cs]
dotnet_diagnostic.FLTYF03.severity = none
```